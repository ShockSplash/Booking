using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Booking.BusinessLogic.Handlers.GetAllHotels;
using Booking.BusinessLogic.Handlers.GetRoomsAggregate;
using Booking.BussinesLogic.Handlers.GetHotelsList;
using Booking.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GetRoomsAggregateRequest = Booking.BussinesLogic.Handlers.GetRoomsAggregate.GetRoomsAggregateRequest;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetHotelsListResponse> GetHotelsList([FromQuery] GetHotelsListRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
        
        [HttpGet("aggregate")]
        public async Task<GetRoomsAggregateResponse> GetAggregate([FromQuery] GetRoomsAggregateRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
        
        [HttpGet("all")]
        public async Task<IEnumerable<HotelDtoModel>> Index([FromQuery]GetAllHotelsRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
    }
}