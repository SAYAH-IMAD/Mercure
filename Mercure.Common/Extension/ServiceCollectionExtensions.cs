using Microsoft.Extensions.DependencyInjection;

namespace Mercure.Common.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthorizatinHeaderPropagation(this IServiceCollection services)
        {
            services.AddHeaderPropagation(options => options.Headers.Add("authorization"));
        }      
    }
}
