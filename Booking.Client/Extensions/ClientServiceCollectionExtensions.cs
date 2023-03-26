using MatBlazor;
using Microsoft.Extensions.DependencyInjection;
using Radzen;

namespace BlazorClient.Folder
{
    public static class ClientServiceCollectionExtensions
    {
        public static void AddBlazorLibraries(this IServiceCollection services)
        { 
            services.AddMatBlazor();
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
        }
    }
}