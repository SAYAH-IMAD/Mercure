using Mercure.Common.Extension;
using Mercure.User.Infrastructure.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Mercure.User.Infrastructure.Security
{
    public class UserProvider : IUserProvider
    {
        readonly IHttpContextAccessor _context;

        public UserProvider(IHttpContextAccessor context)
        {
            _context = context;
        }

        public User CurrentUser
        {
            get
            {
                return new User()
                {
                    Id = int.Parse(_context.GetClaim(ClaimsTypes.Id)),
                    Email = _context.GetClaim(ClaimsTypes.Email),
                    Permissions = _context.GetClaims(ClaimsTypes.Permissions),
                    Roles = _context.GetClaims(ClaimsTypes.Roles)
                };
            }
        }
    }
}
