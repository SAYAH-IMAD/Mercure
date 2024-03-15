using Mercure.Common.Persistance;
using Mercure.Common.Persistence.Transactions;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Query;

namespace Mercure.User.Infrastructure.Persistence.Transaction
{
    internal class UserStateTransaction : ITransaction<UserStateModel>
    {
        readonly IAccessDB _access;

        public UserStateTransaction(IAccessDB accessDB)
        {
            _access = accessDB;
        }

        public IAccessDB Access => _access;

        public bool Delete(UserStateModel persistence, params object[] parentKeys)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id}
            };

            _access.Execute(UserStateQueries.Delete, parameters);

            return true;
        }

        public UserStateModel GetByIdentifier(long identifier)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", identifier}
            };

            var result = _access.ReadFirst<UserStateModel>(UserStateQueries.GetById, parameters);

            return result;
        }

        public List<UserStateModel> GetByParentKey(params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;

            Dictionary<string, object> parameters = new()
            {
                { "@USER_ID",userId},
            };

            var result = _access.Read<UserStateModel>(UserStateQueries.GetByParentKey, parameters).ToList();

            return result;
        }

        public bool Insert(UserStateModel persistence, params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;
            persistence.Id = _access.GetSequence("USER_STATE_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id},
                { "@CREATION_DATE",persistence.CreationDate},
                { "@CODE",persistence.Code.Code},
                { "@USER_ID",userId},
            };

            _access.Execute<UserStateModel>(UserStateQueries.Insert, parameters);

            return true;
        }

        public bool Update(UserStateModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }
    }
}
