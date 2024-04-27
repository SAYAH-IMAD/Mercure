using Microsoft.Extensions.DependencyInjection;

namespace Mercure.Common.Extension
{
    public static class HttpClientBuilderExtensions
    {
        public static void AddAuthorizatinHeaderPropagation(this IHttpClientBuilder services)
        {
            services.AddHeaderPropagation(options => options.Headers.Add("authorization"));
        }
    }
}
