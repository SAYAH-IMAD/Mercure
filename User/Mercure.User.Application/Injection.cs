using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mercure.User.Application
{
    public static class Injection
    {
        public static void AddApplication(this IServiceCollection services) 
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
