using Mercure.User.Infrastructure.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace Mercure.User.Infrastructure.Security.Token
{
    public class TokenProvider : ITokenProvider
    {
        readonly IConfiguration _configuration;

        public TokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(int id, string email, List<string> roles, List<string> permissions)
        {
            if (email == null) throw new ArgumentNullException(nameof(email));

            string issuer = _configuration["Jwt:Issuer"];
            string audience = _configuration["Jwt:Audience"];
            string secret = _configuration["Jwt:Key"];
            string expiration = _configuration["Jwt:ExpirationInMinutes"];

            List<Claim> claims = new()
            {
                new Claim(ClaimsTypes.Id, id.ToString()),
                new Claim(ClaimsTypes.Email, email),
            };

            roles.ForEach(role => claims.Add(new Claim(ClaimsTypes.Roles, role)));
            //TODO : Integrate Permissions 
            //permissions.ForEach(permission => claims.Add(new Claim(ClaimsTypes.Permissions, permission)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(expiration));

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
