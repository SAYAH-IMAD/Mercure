using Mercure.Common.Persistence.DataReader;
using Mercure.IdentityServer.Repository.UserIdentity.Model;
using static Dapper.SqlMapper;

namespace Mercure.IdentityServer.Repository.UserIdentity
{
    public class UserClaimsRepository : IUserClaimsRepository
    {
        readonly IAccessDB _access;

        public UserClaimsRepository(IAccessDB access)
        {
            _access = access;
        }

        public UserClaims FindBySubjectId(string subjectId)
        {


            string sql = "SELECT U.[ID],CONCAT(U.[FIRST_NAME], '_',U.[LAST_NAME]) AS USERNAME,U.[EMAIL],U.[PASSWORD],U.[BIRTH_DATE],U.[STREET],U.[CITY],U.[POSTAL_CODE] FROM [USER] U  WHERE U.[ID] = @ID;" +
                         "SELECT[Title] FROM [UserManagement].[dbo].[PROFILE] P JOIN [UserManagement].[dbo].[USER_PROFILE] UP ON [UP].[PROFILE_ID] = [P].[ID] where UP.[USER_ID] = @ID;";

            Func<GridReader, UserClaims> converter = (reader) =>
            {
                UserClaims user = reader.ReadFirst<UserClaims>();
                user.Roles = reader.Read<string>().ToList();

                return user;

            };
            return _access.QueryMultiple<UserClaims>(sql, new Dictionary<string, object>()
                      {
                         {
                           "@ID", subjectId
                         }
                      }, converter);
        }

        public UserClaims FindByUsername(string username)
        {
          

            return _access.ReadFirst<UserClaims>("SELECT U.[ID],CONCAT(U.[FIRST_NAME], '_',U.[LAST_NAME]) AS USERNAME,U.[EMAIL],U.[PASSWORD],U.[BIRTH_DATE],U.[STREET],U.[CITY],U.[POSTAL_CODE] FROM [USER] U  WHERE U.[EMAIL] = @EMAIL",
                     new Dictionary<string, object>()
                     {
                         {
                           "@EMAIL", username
                         }
                     });
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
