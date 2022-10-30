using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DataLayer.Entities.City
{
    public class CityConfiguration : BaseEntityConfiguration<CityEntity.City>
    {
        public override void Configure(EntityTypeBuilder<CityEntity.City> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(500);
            
            base.Configure(builder);
        }
    }
}