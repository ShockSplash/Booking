using System;
using FluentValidation;

namespace Booking.BussinesLogic.Handlers.GetHotelsList
{
    public class GetHotelsListRequestValidator : AbstractValidator<GetHotelsListRequest>
    {
        public GetHotelsListRequestValidator()
        {
            RuleFor(x => x.Seats)
                .GreaterThan(0)
                .LessThanOrEqualTo(5);

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate);

            RuleFor(x => x.StartDate)
                .GreaterThan(DateTime.Now);
        }
    }
}