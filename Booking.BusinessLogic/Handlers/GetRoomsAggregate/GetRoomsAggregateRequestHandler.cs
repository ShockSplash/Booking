using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Booking.BusinessLogic.Handlers.GetRoomsAggregate;
using Booking.BussinesLogic.Handlers.GetHotelsList;
using Booking.DataLayer;
using Booking.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Booking.BussinesLogic.Handlers.GetRoomsAggregate
{
    public class GetRoomsAggregateRequestHandler : IRequestHandler<GetRoomsAggregateRequest, GetRoomsAggregateResponse>
    {
        private readonly BookingDbContext _dbContext;

        public GetRoomsAggregateRequestHandler(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetRoomsAggregateResponse> Handle(GetRoomsAggregateRequest request, CancellationToken cancellationToken)
        {
            var hotel = await _dbContext.Hotels
                .Include(x => x.City)
                .Where(x => x.Id == request.HotelId)
                .Select(x => new HotelsResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CityName = x.City.Name,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Description = x.Description
                })
                .SingleAsync(cancellationToken);

            //a.start <= b.end AND a.end >= b.start
            var occupiedRoomIds = await _dbContext.Bookings
                .Where(b => b.BeginDate <= request.EndDate && b.EndDate >= request.StartDate)
                .Where(x => x.HotelId == request.HotelId)
                .Select(b => b.RoomId)
                .Distinct()
                .ToArrayAsync(cancellationToken);
            
            var rooms = await _dbContext.Rooms
                .Where(x => x.HotelId == request.HotelId)
                .Include(x => x.Hotel)
                .ThenInclude(x => x.City)
                .Include(x => x.Bookings)
                .Where(x => x.Seats == request.Seats)
                .Where(r => !occupiedRoomIds.Contains(r.Id))
                .Select(x => new RoomsResponseUnit
                {
                    Id = x.Id,
                    Seats = x.Seats,
                    Type = x.RoomType.ToString(),
                    Description = x.Description
                })
                .ToArrayAsync(cancellationToken);
            
            return new GetRoomsAggregateResponse
            {
                Rooms = rooms,
                Hotel = hotel
            };
        }
    }
}