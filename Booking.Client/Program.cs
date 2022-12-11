using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Booking.DataLayer.Extensions;
using FluentValidation;
using MatBlazor;
using MediatR;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;

namespace Booking.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            
            builder.Services.AddMatBlazor();

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            builder.Services.AddBookingDbContext(builder.Configuration);
            builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
            builder.Services.AddMediatR(typeof(Program));
            
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            /*builder.Services.AddOidcAuthentication(options =>
            {
                options.ProviderOptions.Authority = "https://localhost:5000/";
                options.ProviderOptions.ClientId = "blazor";
                options.ProviderOptions.ResponseType = "code";
                options.ProviderOptions.PostLogoutRedirectUri = @"\";
            });*/
            
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("oidc", options.ProviderOptions);
            });

            await builder.Build().RunAsync();
        }
    }
}
