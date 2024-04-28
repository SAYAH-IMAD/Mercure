using Mercure.IdentityServer.Repository.UserIdentity.Model;

namespace Mercure.IdentityServer.Repository.UserIdentity
{
    public interface IUserClaimsRepository
    {
        bool ValidateCredentials(string username, string password);

        UserClaims FindBySubjectId(string subjectId);

        UserClaims FindByUsername(string username);
    }
}
