using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Booking.BussinesLogic.Handlers.City.GetAllCities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get(CancellationToken cancellationToken)
            => await _mediator.Send(new GetAllCitiesRequest(), cancellationToken);
    }
}