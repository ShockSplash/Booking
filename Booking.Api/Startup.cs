using Booking.BussinesLogic.Handlers.City.GetAllCities;
using Booking.DataLayer.Extensions;
using Booking.DataLayer.Shared;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace WeatherApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Booking API",
                    Description = "Booking API"
                });
            });

            services.AddSerilogServices();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5000";
                    options.Audience = "bookingapi";
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        NameClaimType = "name"
                    };
                });
            
            services.AddBookingDbContext(Configuration);
            
            services.AddValidatorsFromAssemblyContaining(typeof(Startup));
            services.AddMediatR(typeof(GetAllCitiesRequest));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(config => 
            {
                config.AllowAnyOrigin();
                config.AllowAnyMethod();
                config.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
