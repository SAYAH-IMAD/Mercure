using Dapper;
using Mercure.IdentityServer.Repository.UserIdentity.Model;
using Microsoft.Data.SqlClient;

namespace Mercure.IdentityServer.Repository.UserIdentity
{
    public class UserClaimsRepository : IUserClaimsRepository
    {
        public UserClaims FindBySubjectId(string subjectId)
        {
            string userQuery = "SELECT U.[ID],CONCAT(U.[FIRST_NAME], '_',U.[LAST_NAME]) AS USERNAME,U.[EMAIL],U.[PASSWORD],U.[BIRTH_DATE],U.[STREET],U.[CITY],U.[POSTAL_CODE] FROM [USER] U  WHERE U.[ID] = @ID;";
            string rolesQuery = "SELECT [Title] AS Role FROM [UserManagement].[dbo].[PROFILE] P JOIN [UserManagement].[dbo].[USER_PROFILE] UP ON [UP].[PROFILE_ID] = [P].[ID] where UP.[USER_ID] = @ID;";

            UserClaims claims = null;

            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=UserManagement;Integrated Security=True;Encrypt=False"))
            {
                claims = connection.QueryFirst<UserClaims>(userQuery, new Dictionary<string, object>()
                {
                    {
                      "@ID", subjectId
                    }
                });
            }

            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=UserManagement;Integrated Security=True;Encrypt=False"))
            {
                claims.Roles = connection.Query<RoleClaim>(rolesQuery, new Dictionary<string, object>()
                {
                    {
                      "@ID", subjectId
                    }
                });
            }

            return claims;
        }

        public UserClaims FindByUsername(string username)
        {
            string userQuery = "SELECT U.[ID],CONCAT(U.[FIRST_NAME], '_',U.[LAST_NAME]) AS USERNAME,U.[EMAIL],U.[PASSWORD],U.[BIRTH_DATE],U.[STREET],U.[CITY],U.[POSTAL_CODE] FROM [USER] U  WHERE U.[EMAIL] = @EMAIL";
            string rolesQuery = "SELECT [Title] AS Role FROM [UserManagement].[dbo].[PROFILE] P JOIN [UserManagement].[dbo].[USER_PROFILE] UP ON [UP].[PROFILE_ID] = [P].[ID] where UP.[USER_ID] = @ID;";

            UserClaims claims = null;

            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=UserManagement;Integrated Security=True;Encrypt=False"))
            {
                claims =  connection.QueryFirstOrDefault<UserClaims>(userQuery, new Dictionary<string, object>()
                {
                    {
                      "@EMAIL", username
                    }
                });
            }

            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=UserManagement;Integrated Security=True;Encrypt=False"))
            {
                claims.Roles = connection.Query<RoleClaim>(rolesQuery, new Dictionary<string, object>() 
                {
                    {
                      "@ID", claims.Id
                    }
                });
            }

            return claims;
        }

        public bool ValidateCredentials(string username, string password)
        {
            UserClaims user = FindByUsername(username);

            if (user is not null)
            {
                return user.Password.Equals(password);
            }

            return false;
        }
    }
}
