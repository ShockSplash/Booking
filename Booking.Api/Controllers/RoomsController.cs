using System.Threading;
using System.Threading.Tasks;
using Booking.BusinessLogic.Handlers.GetInfoByRoom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetInfoByRoomResponse> GetRoomById([FromQuery] GetInfoByRoomRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
    }
}