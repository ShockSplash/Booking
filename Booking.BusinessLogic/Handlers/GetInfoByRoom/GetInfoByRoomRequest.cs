using System;
using MediatR;

namespace Booking.BusinessLogic.Handlers.GetInfoByRoom
{
    public class GetInfoByRoomRequest : IRequest<GetInfoByRoomResponse>
    {
        public Guid RoomId { get; set; }
    }
}