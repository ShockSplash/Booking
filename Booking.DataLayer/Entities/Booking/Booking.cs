using System;

namespace Booking.DataLayer.Entities
{
    public class Booking : BaseEntity
    {
        public DateTimeOffset BeginDate { get; init; }

        public DateTimeOffset EndDate { get; init; }

        public Guid UserId { get; init; }

        public Guid RoomId { get; init; }

        public Room Room { get; init; }

        public Guid HotelId { get; init; }

        public Hotel Hotel { get; init; }
    }
}