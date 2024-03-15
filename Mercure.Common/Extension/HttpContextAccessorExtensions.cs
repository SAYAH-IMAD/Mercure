using Microsoft.AspNetCore.Http;

namespace Mercure.Common.Extension
{
    public static class HttpContextAccessorExtensions
    {

        public static List<string> GetClaims(this IHttpContextAccessor context, string claimType) =>
            context.HttpContext!.User.Claims
            .Where(claim => claim.Type == claimType)
            .Select(claim => claim.Value)
            .ToList();

        public static string GetClaim(this IHttpContextAccessor context, string claimType) =>
            context.HttpContext!.User.Claims
            .Single(claim => claim.Type == claimType)
            .Value;
    }
}
