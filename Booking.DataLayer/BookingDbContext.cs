using Booking.DataLayer.Entities;
using Booking.DataLayer.Entities.City;
using Booking.DataLayer.Entities.CityEntity;
using Booking.DataLayer.Entities.User;
using Booking.DataLayer.Extensions;
using Booking.DataLayer.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Booking.DataLayer
{
    public sealed class BookingDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public BookingDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Room> Rooms { get; set; } = null!;

        public DbSet<Hotel> Hotels { get; set; } = null!;

        public DbSet<City> Cities { get; set; } = null!;

        public DbSet<Entities.Booking> Bookings { get; set; } = null!;

        static BookingDbContext()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Sex>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<RoomType>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.HasPostgresEnum<Sex>();
            modelBuilder.HasPostgresEnum<RoomType>();

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DataLayerExtensions.BuildConnectionString(_configuration));
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}