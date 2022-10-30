using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DataLayer.Entities
{
    public class BookingConfiguration : BaseEntityConfiguration<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
            base.Configure(builder);
        }
    }
}