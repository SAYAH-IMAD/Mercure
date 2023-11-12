using Mercure.Common;
using Mercure.Common.Persistence.Transactions;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Query;

namespace Mercure.User.Infrastructure.Persistence.Transaction
{
    public class UserProfileTransaction : ITransaction<UserProfileModel>
    {
        readonly IAccessDB _access;

        public UserProfileTransaction(IAccessDB accessDB)
        {
            _access = accessDB;
        }

        public bool Delete(UserProfileModel persistence, params object[] parentKeys)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id}
            };

            _access.Execute(UserProfileQueries.Delete, parameters);

            return true;
        }

        public UserProfileModel GetByIdentifier(long identifier)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", identifier}
            };

            var result = _access.ReadFirst<UserProfileModel>(UserProfileQueries.GetById, parameters);

            return result;
        }

        public List<UserProfileModel> GetByParentKey(params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;

            Dictionary<string, object> parameters = new()
            {
                { "@USER_ID",userId},
            };

            var result = _access.Read<UserProfileModel>(UserProfileQueries.GetByParentKey, parameters).ToList();

            return result;
        }

        public bool Insert(UserProfileModel persistence, params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;
            persistence.Id = _access.GetSequence("USER_PROFILE_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id},
                { "@CREATION_DATE",persistence.CreationDate},
                { "@PROFILE_ID",persistence.ProfileId},
                { "@USER_ID",userId},
            };

            _access.Execute<UserProfileModel>(UserProfileQueries.Insert, parameters);

            return true;
        }

        public bool Update(UserProfileModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }
    }
}
