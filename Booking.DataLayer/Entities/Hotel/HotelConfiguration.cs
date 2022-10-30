using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DataLayer.Entities
{
    public class HotelConfiguration : BaseEntityConfiguration<Hotel>
    {
        public override void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(500);
            
            base.Configure(builder);
        }
    }
}