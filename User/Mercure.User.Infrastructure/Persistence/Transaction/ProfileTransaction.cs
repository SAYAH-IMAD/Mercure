using Mercure.Common;
using Mercure.Common.Persistence.Transactions;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Query;

namespace Mercure.User.Infrastructure.Persistence.Transaction
{
    public class ProfileTransaction : ITransaction<ProfileModel>
    {
        readonly IAccessDB _access;

        public ProfileTransaction(IAccessDB access)
        {
            _access = access;
        }

        public bool Delete(ProfileModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public ProfileModel GetByIdentifier(long identifier)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@Id", identifier}
            };

            var result = _access.ReadFirst<ProfileModel>(ProfileQueries.GetById, parameters);

            return result;
        }

        public List<ProfileModel> GetByParentKey(params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;

            Dictionary<string, object> parameters = new()
            {
                { "@UserId",userId},
            };

            var result = _access.Read<ProfileModel>(ProfileQueries.GetByParentKey, parameters).ToList();

            return result;
        }

        public bool Insert(ProfileModel persistence, params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;
            persistence.Id = _access.GetSequence("PROFILE_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@Id", persistence.Id},
                { "@Title",persistence.Title},
                { "@UserId",userId},
            };

            _access.Execute<ProfileModel>(ProfileQueries.Insert, parameters);

            return true;
        }

        public bool Update(ProfileModel persistence, params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;

            Dictionary<string, object> parameters = new()
            {
                { "@Id",persistence.Id.Value},
                { "@Title",persistence.Title},
            };

            _access.Execute<ProfileModel>(ProfileQueries.Update, parameters);

            return true;
        }
    }
}
