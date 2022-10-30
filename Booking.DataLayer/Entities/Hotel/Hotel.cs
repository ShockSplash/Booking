#nullable enable
using System;
using System.Collections.Generic;

namespace Booking.DataLayer.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; init; }

        public Guid? CityId { get; init; }

        public CityEntity.City? City { get; init; }


        #region NavigationProperies

        public List<Room> Rooms { get; init; }

        #endregion
    }
}