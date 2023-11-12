using ChangeTracking;
using Mercure.Common;
using Mercure.Common.Extension;
using Mercure.Common.Persistence.Transactions;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Query;

namespace Mercure.User.Infrastructure.Persistence.Transaction
{
    public class UserTransaction : ITransaction<UserModel>
    {
        readonly IAccessDB _access;
        readonly ITransaction<UserStateModel> _userStateTransaction;
        readonly ITransaction<UserProfileModel> _userProfileTransaction;

        public UserTransaction(IAccessDB access,
            ITransaction<UserStateModel> userStateTransaction,
            ITransaction<UserProfileModel> userProfileTransaction)
        {
            _access = access;
            _userStateTransaction = userStateTransaction;
            _userProfileTransaction = userProfileTransaction;
        }

        public bool Delete(UserModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByIdentifier(long identifier)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", identifier}
            };

            var result = _access.ReadFirst<UserModel>(UserQueries.Get, parameters);

            result.HistoryStates = _userStateTransaction.GetByParentKey(result.Id);
            result.Profiles = _userProfileTransaction.GetByParentKey(result.Id);

            return result;
        }

        public List<UserModel> GetByParentKey(params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UserModel persistence, params object[] parentKeys)
        {
            persistence.Id = _access.GetSequence("USER_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id},
                { "@FIRST_NAME",persistence.FirstName},
                { "@LAST_NAME",persistence.LastName},
                { "@STREET",persistence.Street},
                { "@CITY",persistence.City},
                { "@POSTAL_CODE",persistence.PostalCode},
                { "@BIRTH_DATE",persistence.BirthDate},
            };

            _access.Execute<UserModel>(UserQueries.Insert, parameters);

            foreach (var historyState in persistence.HistoryStates)
            {
                _userStateTransaction.Insert(historyState);
            }

            foreach (var profile in persistence.Profiles)
            {
                _userProfileTransaction.Insert(profile);
            }

            return true;
        }

        public bool Update(UserModel persistence, params object[] parentKeys)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id},
                { "@FIRST_NAME",persistence.FirstName},
                { "@LAST_NAME",persistence.LastName},
                { "@STREET",persistence.Street},
                { "@CITY",persistence.City},
                { "@POSTAL_CODE",persistence.PostalCode},
                { "@BIRTH_DATE",persistence.BirthDate},
            };

            _access.Execute<UserModel>(UserQueries.Update, parameters);


            foreach (var historyState in persistence.HistoryStates)
            {
                _userStateTransaction.ApplyChanges(historyState, persistence.Id);
            }

            foreach (var profile in persistence.Profiles)
            {
                _userProfileTransaction.ApplyChanges(profile, persistence.Id);
            }

            return true;
        }
    }
}
