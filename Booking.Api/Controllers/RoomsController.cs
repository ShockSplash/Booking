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

        /// <summary>
        /// Получение списка комнат
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetInfoByRoomResponse> GetRooms([FromQuery] GetAllRoomsRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
        
        /// <summary>
        /// Добавление комнаты
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> AddRoom([FromQuery] AddRoomRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
        
        /// <summary>
        /// Обновление комнаты
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<bool> UpdateRoom([FromQuery] UpdateRoomRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
    }
}