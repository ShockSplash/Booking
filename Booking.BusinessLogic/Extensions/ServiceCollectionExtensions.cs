using System.Linq;
using System.Reflection;
using Booking.BusinessLogic;
using Booking.DataLayer;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.BussinesLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAllHandlersPipeline(this IServiceCollection services)
        {
            var assemblies = GetAllAssemblies();
            services.AddMediatR(assemblies);
            services.AddValidatorsFromAssemblies(assemblies);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
        
        private static Assembly[] GetAllAssemblies()
        {
            var assembly1 = Assembly.GetEntryAssembly();
            if ((object) assembly1 == null)
                assembly1 = Assembly.GetCallingAssembly();
            var assembly2 = assembly1;
            var list = assembly2.GetReferencedAssemblies().Select(Assembly.Load).ToList();
            list.Add(assembly2);
            return list.Distinct().ToArray();
        }
    }
}