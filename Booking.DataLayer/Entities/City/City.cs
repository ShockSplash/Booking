using System.Collections.Generic;

namespace Booking.DataLayer.Entities.CityEntity
{
    public class City : BaseEntity
    {
        public float? TimeZone { get; set; }
        
        public string Name { get; init; }

        public List<Hotel> Hotels { get; init; }
    }
}