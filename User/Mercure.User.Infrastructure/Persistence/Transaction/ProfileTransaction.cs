using Mercure.Common.Persistence.DataReader;
using Mercure.Common.Persistence.Transactions;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Query;

namespace Mercure.User.Infrastructure.Persistence.Transaction
{
    public class ProfileTransaction : ITransaction<ProfileModel>
    {
        public IDBContext Context { get; private set; }
        readonly ITransaction<RoleModel> RoleTransaction;

        public ProfileTransaction(IDBContext context,
            ITransaction<RoleModel> role)
        {
            Context = context;
            RoleTransaction = role;
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

            var result = Context.ReadFirst<ProfileModel>(ProfileQueries.GetById, parameters);

            result.Roles = RoleTransaction.GetByParentKey(result.Id);

            return result;
        }

        public List<ProfileModel> GetByParentKey(params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;

            Dictionary<string, object> parameters = new()
            {
                { "@UserId",userId},
            };

            var result = Context.Read<ProfileModel>(ProfileQueries.GetByParentKey, parameters).ToList();

            return result;
        }

        public bool Insert(ProfileModel persistence, params object[] parentKeys)
        {
            //long? userId = parentKeys[0] as long?;
            persistence.Id = Context.GetSequence("PROFILE_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@Id", persistence.Id},
                { "@Title",persistence.Title},
                //{ "@UserId",userId},
            };

            Context.Execute<ProfileModel>(ProfileQueries.Insert, parameters);

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

            Context.Execute<ProfileModel>(ProfileQueries.Update, parameters);

            return true;
        }
    }
}
