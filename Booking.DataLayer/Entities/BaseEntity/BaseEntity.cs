using System;

namespace Booking.DataLayer.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; init; }

        public bool IsActive { get; init; }

        public DateTimeOffset CreatedOn { get; init; }

        public DateTimeOffset ModifiedOn { get; init; }
    }
}