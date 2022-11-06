using Booking.DataLayer.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Booking.DataLayer.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection AddBookingDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingDbContext>(options =>
                options.UseNpgsql(BuildConnectionString(configuration)));

            return services;
        }
        
        public static string BuildConnectionString(IConfiguration configuration)
        {
            return configuration
                .GetSection(nameof(NpgsqlConnection))
                .Get<NpgsqlConnectionStringBuilder>()
                .ToString()!;
        }
    }
}