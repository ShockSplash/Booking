using System.Threading.Tasks;
using Booking.BussinesLogic.Handlers.GetHotelsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(GetHotelsListRequest request)
            => Ok(await _mediator.Send(request));
    }
}