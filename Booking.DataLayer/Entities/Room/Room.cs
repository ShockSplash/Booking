using System;
using System.Collections.Generic;

namespace Booking.DataLayer.Entities
{
    public class Room : BaseEntity
    {
        public int Seats { get; init; }

        public double PricePerDay { get; init; }
        
        public string Description { get; set; }

        public RoomType RoomType { get; init; }

        #region Navigation
        
        public Guid HotelId { get; init; }

        public Hotel Hotel { get; init; }
        
        public List<Booking> Bookings { get; init; }
        
        #endregion
    }
    
}