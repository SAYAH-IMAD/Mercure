using IdentityServer4;
using IdentityServer4.Models;

namespace Mercure.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public static IEnumerable<Client> Clients =>
         [
            new Client()
            {
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                AccessTokenType = AccessTokenType.Jwt,
                AccessTokenLifetime = 120, //86400,
                IdentityTokenLifetime = 120, //86400,
                UpdateAccessTokenClaimsOnRefresh = true,
                SlidingRefreshTokenLifetime = 30,
                AllowOfflineAccess = true,
                RefreshTokenExpiration = TokenExpiration.Absolute,
                RefreshTokenUsage = TokenUsage.OneTimeOnly,
                AlwaysSendClientClaims = true,
                Enabled = true,
                ClientId = "client",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = {
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile,
                     IdentityServerConstants.StandardScopes.Email,
                     IdentityServerConstants.StandardScopes.OfflineAccess,
                    "api" 
                },
            }
         ];

        public static IEnumerable<ApiScope> ApiScopes =>
           [
               new ApiScope()
               {
                   Name = "api"
               },
             new ApiScope()
               {
                   Name = IdentityServerConstants.StandardScopes.OpenId
               }, new ApiScope()
               {
                   Name = IdentityServerConstants.StandardScopes.Profile
               }, new ApiScope()
               {
                   Name = IdentityServerConstants.StandardScopes.Email
               }, new ApiScope()
               {
                   Name = IdentityServerConstants.StandardScopes.OfflineAccess
               },
           ];

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource> { };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource> { };
    }
}
