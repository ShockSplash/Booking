using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DataLayer.Entities
{
    public class RoomConfiguration : BaseEntityConfiguration<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);
        }
    }
}