using System;
using MediatR;

namespace Booking.BusinessLogic.Handlers.GetInfoByRoom
{
    public class GetInfoByRoomRequest : IRequest<GetInfoByRoomResponse>
    {
        public Guid RoomId { get; set; }
    }
    public class GetAllRoomsRequest : IRequest<GetInfoByRoomResponse>
    {
        public Guid RoomId { get; set; }
    }
    
    public class AddRoomRequest : IRequest<bool>
    {
        public Guid RoomId { get; set; }
    }
    
    public class UpdateRoomRequest : IRequest<bool>
    {
        public Guid RoomId { get; set; }
    }
}