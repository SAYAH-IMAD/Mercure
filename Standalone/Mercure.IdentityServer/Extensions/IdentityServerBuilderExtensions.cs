using Mercure.IdentityServer.Repository.UserIdentity;
using Mercure.IdentityServer.Service.Profile;
using Mercure.IdentityServer.Service.Resource;

namespace Mercure.IdentityServer.Extensions
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddInMemoryUser(this IIdentityServerBuilder builder)
        {
            builder.Services.AddSingleton<IUserClaimsRepository, UserClaimsRepository>();
            builder.AddProfileService<ProfileService>();
            builder.AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();

            return builder;
        }
    }
}
