using System;

namespace BlazorClient.ClientModels
{
    public class BookRequest
    {
        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public Guid RoomId { get; set; }
    }
}