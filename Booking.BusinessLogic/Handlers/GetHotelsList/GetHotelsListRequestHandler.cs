using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Booking.DataLayer;
using Booking.DataLayer.Entities;
using Booking.DataLayer.Extensions;
using Booking.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Booking.BussinesLogic.Handlers.GetHotelsList
{
    public class GetHotelsListRequestHandler : IRequestHandler<GetHotelsListRequest, GetHotelsListResponse>
    {
        private readonly BookingDbContext _dbContext;

        public GetHotelsListRequestHandler(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetHotelsListResponse> Handle(GetHotelsListRequest request, CancellationToken cancellationToken)
        {
            //a.start <= b.end AND a.end >= b.start
            var occupiedRoomIds = await _dbContext.Bookings
                .Where(b => b.BeginDate <= request.EndDate && b.EndDate >= request.StartDate)
                .Select(b => b.RoomId)
                .Distinct()
                .ToArrayAsync(cancellationToken);
            
            var availableHotels = await _dbContext.Rooms
                .Include(x => x.Hotel)
                .ThenInclude(x => x.City)
                .Where(x => x.Seats == request.Seats)
                .Where(x => x.Hotel.City.Name == request.City)
                .Where(r => !occupiedRoomIds.Contains(r.Id))
                .Select(x => new HotelDtoModel
                {
                    HotelCity = x.Hotel.City.Name,
                    Id = x.HotelId,
                    Name = x.Hotel.Name,
                })
                .Distinct()
                .ToArrayAsync(cancellationToken);


            return new GetHotelsListResponse
            {
                Hotels = availableHotels
            };
        }
    }
}