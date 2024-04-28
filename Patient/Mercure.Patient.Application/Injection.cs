using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mercure.Patient.Application
{
    public static class Injection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
