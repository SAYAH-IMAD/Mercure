namespace Mercure.Patient.API.Middleware
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");

            await _next(httpContext);

            httpContext.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");
        }
    }
}
