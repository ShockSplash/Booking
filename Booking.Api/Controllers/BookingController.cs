using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Booking.BusinessLogic.Handlers.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<Unit> Book([FromBody] BookRoomRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
    }
}