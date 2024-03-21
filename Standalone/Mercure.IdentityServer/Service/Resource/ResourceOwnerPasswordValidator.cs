using IdentityModel;
using IdentityServer4.Validation;
using Mercure.IdentityServer.Repository.UserIdentity;
using Mercure.IdentityServer.Repository.UserIdentity.Model;

namespace Mercure.IdentityServer.Service.Resource
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        readonly IUserClaimsRepository _repository;

        public ResourceOwnerPasswordValidator(IUserClaimsRepository repository)
        {
            _repository = repository;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_repository.ValidateCredentials(context.UserName, context.Password))
            {
                UserClaims user = _repository.FindByUsername(context.UserName);
                context.Result = new GrantValidationResult(user.Id, OidcConstants.AuthenticationMethods.Password);
            }

            return Task.FromResult(0);
        }
    }
}
