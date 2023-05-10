using System;

namespace Booking.Shared.Models
{
    public class HotelDtoModel : IEquatable<HotelDtoModel>
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string HotelCity { get; set; }

        public int? Rate { get; set; }

        public string Description { get; set; }

        public bool Equals(HotelDtoModel other)
        {
            if (other is null)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is HotelDtoModel model)
            {
                return Equals(model);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, HotelCity);
        }
    }
}