using System;
using MediatR;

namespace Booking.BusinessLogic.Handlers.Book
{
    public class BookRoomRequest : IRequest
    {
        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public Guid RoomId { get; set; }
    }
}