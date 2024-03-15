using Mercure.Common.Persistance;
using Mercure.Common.Persistence.Transactions;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Query;

namespace Mercure.User.Infrastructure.Persistence.Transaction
{
    public class ProfileTransaction : ITransaction<ProfileModel>
    {
        public IAccessDB Access { get; private set; }

        public ProfileTransaction(IAccessDB access)
        {
            Access = access;
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

            var result = Access.ReadFirst<ProfileModel>(ProfileQueries.GetById, parameters);

            return result;
        }

        public List<ProfileModel> GetByParentKey(params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;

            Dictionary<string, object> parameters = new()
            {
                { "@UserId",userId},
            };

            var result = Access.Read<ProfileModel>(ProfileQueries.GetByParentKey, parameters).ToList();

            return result;
        }

        public bool Insert(ProfileModel persistence, params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;
            persistence.Id = Access.GetSequence("PROFILE_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@Id", persistence.Id},
                { "@Title",persistence.Title},
                { "@UserId",userId},
            };

            Access.Execute<ProfileModel>(ProfileQueries.Insert, parameters);

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

            Access.Execute<ProfileModel>(ProfileQueries.Update, parameters);

            return true;
        }
    }
}
