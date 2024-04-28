using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mercure.Common.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthorizatinHeaderPropagation(this IServiceCollection services)
        {
            services.AddHeaderPropagation(options => options.Headers.Add("authorization"));
        }

        //public static void AddAuthorizatinHeaderPropagation1<T>(this IServiceCollection services, object instance)
        //{
        //    services.Configure<T>(option => Configuration.GetValue<T>(null));
        //}
    }
}
