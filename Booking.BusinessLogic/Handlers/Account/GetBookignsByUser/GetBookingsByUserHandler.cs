using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Booking.BusinessLogic.Handlers.GetInfoByRoom;
using Booking.DataLayer;
using Booking.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Booking.BusinessLogic.Handlers.Account.GetBookignsByUser
{
    public class GetBookingsByUserHandler : IRequestHandler<GetBookingsByUserRequest, GetBookingsByUserResponse[]>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BookingDbContext _dbContext;

        public GetBookingsByUserHandler(IHttpContextAccessor httpContextAccessor, BookingDbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        public async Task<GetBookingsByUserResponse[]> Handle(GetBookingsByUserRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext!.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
                .Select(x => x.Value).First();

            return await _dbContext.Bookings
                .Where(x => x.UserId == new Guid(userId))
                .Include(x => x.Hotel)
                .ThenInclude(x => x.City)
                .Include(x => x.Room)
                .Select(x => new GetBookingsByUserResponse()
                {
                    StartDate = x.BeginDate,
                    EndDate = x.EndDate,
                    Hotel = new HotelDtoModel
                    {
                        Description = x.Hotel.Description,
                        Name = x.Hotel.Name,
                        Id = x.Hotel.Id,
                        HotelCity = x.Hotel!.City!.Name,
                        Rate = x.Hotel.Rate
                    },
                    RoomInfo = new GetInfoByRoomResponse
                    {
                        Seats = x.Room.Seats,
                        PricePerDay = x.Room.PricePerDay,
                        RoomDescription = x.Room.Description
                    }
                })
                .ToArrayAsync(cancellationToken);
        }
    }
}