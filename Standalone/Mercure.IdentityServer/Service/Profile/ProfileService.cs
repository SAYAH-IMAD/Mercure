using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Mercure.IdentityServer.Repository.UserIdentity;
using Mercure.IdentityServer.Repository.UserIdentity.Model;
using System.Security.Claims;

namespace Mercure.IdentityServer.Service.Profile
{
    public class ProfileService : IProfileService
    {
        readonly IUserClaimsRepository _repository;

        public ProfileService(IUserClaimsRepository repository)
        {
            _repository = repository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string id = context.Subject.GetSubjectId();

            UserClaims user = _repository.FindBySubjectId(id);

            List<Claim> claims =
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id),  
                new Claim(ClaimTypes.Name, user.UserName),
            ];

            foreach (string role in user.Roles) 
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            string id = context.Subject.GetSubjectId();
            UserClaims user = _repository.FindBySubjectId(id);
            
            context.IsActive = user is not null;
        }
    }
}
