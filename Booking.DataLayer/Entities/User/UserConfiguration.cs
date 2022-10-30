using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.DataLayer.Entities.User
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(80);

            builder.Property(x => x.Login).HasMaxLength(150);

            builder.Property(x => x.Password).HasMaxLength(200);

            builder.Property(x => x.FullName).HasMaxLength(500);
            
            base.Configure(builder);
        }
    }
}