using Microsoft.Extensions.DependencyInjection;

namespace Mercure.Common.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDefaultHeaderPropagation(this IServiceCollection services)
        {
            services.AddHeaderPropagation(options => options.Headers.Add("Authorization"));
            services.AddHeaderPropagation(options => options.Headers.Add("CorrelationId"));
        }
    }
}
