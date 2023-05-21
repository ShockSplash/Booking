using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Booking.DataLayer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Booking.BusinessLogic.Handlers.Book
{
    public class BookRoomRequestHandler : IRequestHandler<BookRoomRequest>
    {
        private readonly BookingDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookRoomRequestHandler(BookingDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(BookRoomRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext!.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier)
                .Select(x => x.Value).First();
            var hotelId = await _dbContext.Rooms
                .Where(x => x.Id == request.RoomId)
                .Select(x => x.HotelId)
                .SingleAsync(cancellationToken);
            var booking = new Booking.DataLayer.Entities.Booking()
            {
                RoomId = request.RoomId,
                BeginDate = request.StartDate,
                EndDate = request.EndDate,
                UserId = new Guid(userId),
                HotelId = hotelId
            };

            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await _dbContext.Database.ExecuteSqlInterpolatedAsync($"LOCK TABLE \"Bookings\" IN SHARE ROW EXCLUSIVE MODE",
                    cancellationToken: cancellationToken);
                await _dbContext.AddAsync(booking, cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}