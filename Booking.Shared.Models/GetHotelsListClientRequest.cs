using System;

namespace Booking.Shared.Models
{
    public class GetHotelsListClientRequest
    {
        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Seats { get; set; }

        public string Type { get; set; }

        public int Rate { get; set; }
    }
}