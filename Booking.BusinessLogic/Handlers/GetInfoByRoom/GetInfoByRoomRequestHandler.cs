using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Booking.DataLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Booking.BusinessLogic.Handlers.GetInfoByRoom
{
    public class GetInfoByRoomRequestHandler : IRequestHandler<GetInfoByRoomRequest, GetInfoByRoomResponse>
    {
        private readonly BookingDbContext _dbContext;

        public GetInfoByRoomRequestHandler(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetInfoByRoomResponse> Handle(GetInfoByRoomRequest request, CancellationToken cancellationToken)
        {
            return await _dbContext.Rooms
                .Include(x => x.Hotel)
                .Where(x => x.Id == request.RoomId)
                .Select(x => new GetInfoByRoomResponse()
                {
                    RoomDescription = x.Description,
                    Seats = x.Seats,
                    PricePerDay = x.PricePerDay,
                    HotelName = x.Hotel.Name,
                    City = x.Hotel.City.Name
                })
                .SingleAsync(cancellationToken);
        }
    }
}