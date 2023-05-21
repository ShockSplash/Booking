using FluentValidation;

namespace Booking.BusinessLogic.Handlers.Book
{
    public class BookRoomRequestValidator : AbstractValidator<BookRoomRequest>
    {
        public BookRoomRequestValidator()
        {
            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate);

            RuleFor(x => x.RoomId)
                .NotEmpty()
                .NotNull();
        }
    }
}