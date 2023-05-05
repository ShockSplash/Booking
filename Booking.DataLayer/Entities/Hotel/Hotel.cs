#nullable enable
using System;
using System.Collections.Generic;

namespace Booking.DataLayer.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public Guid? CityId { get; init; }

        public CityEntity.City? City { get; init; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        #region NavigationProperies

        public List<Room> Rooms { get; init; }
        
        public List<Booking> Bookings { get; init; }

        #endregion
    }
}