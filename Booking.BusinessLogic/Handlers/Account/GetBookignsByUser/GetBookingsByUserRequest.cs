using MediatR;

namespace Booking.BusinessLogic.Handlers.Account.GetBookignsByUser
{
    public record GetBookingsByUserRequest : IRequest<GetBookingsByUserResponse[]>
    {
        
    }
}