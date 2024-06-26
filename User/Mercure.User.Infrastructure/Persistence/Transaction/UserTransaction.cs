﻿using Mercure.Common.Extension;
using Mercure.Common.Persistence.DataReader;
using Mercure.Common.Persistence.Transactions;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Query;

namespace Mercure.User.Infrastructure.Persistence.Transaction
{
    public class UserTransaction : ITransaction<UserModel>
    {
        readonly ITransaction<UserStateModel> UserStateTransaction;
        readonly ITransaction<UserProfileModel> UserProfileTransaction;

        public UserTransaction(IDBContext context,
            ITransaction<UserStateModel> userStateTransaction,
            ITransaction<UserProfileModel> userProfileTransaction)
        {
            Context = context;
            UserStateTransaction = userStateTransaction;
            UserProfileTransaction = userProfileTransaction;
        }

        public IDBContext Context { get; private set; }

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

            var result = Context.ReadFirst<UserModel>(UserQueries.Get, parameters);

            result.HistoryStates = UserStateTransaction.GetByParentKey(result.Id);
            result.Profiles = UserProfileTransaction.GetByParentKey(result.Id);

            return result;
        }

        public List<UserModel> GetByParentKey(params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UserModel persistence, params object[] parentKeys)
        {
            persistence.Id = Context.GetSequence("USER_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id},
                { "@FIRST_NAME",persistence.FirstName},
                { "@LAST_NAME",persistence.LastName},
                { "@EMAIL",persistence.Email},
                { "@PASSWORD",persistence.Password},
                { "@STREET",persistence.Street},
                { "@CITY",persistence.City},
                { "@POSTAL_CODE",persistence.PostalCode},
                { "@BIRTH_DATE",persistence.BirthDate},
            };

            Context.Execute<UserModel>(UserQueries.Insert, parameters);

            foreach (var historyState in persistence.HistoryStates)
            {
                UserStateTransaction.Insert(historyState);
            }

            foreach (var profile in persistence.Profiles)
            {
                UserProfileTransaction.Insert(profile);
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
                { "@EMAIL",persistence.Email},
                { "@PASSWORD",persistence.Password},
                { "@STREET",persistence.Street},
                { "@CITY",persistence.City},
                { "@POSTAL_CODE",persistence.PostalCode},
                { "@BIRTH_DATE",persistence.BirthDate},
            };

            Context.Execute<UserModel>(UserQueries.Update, parameters);


            foreach (var historyState in persistence.HistoryStates)
            {
                UserStateTransaction.ApplyChanges(historyState, persistence.Id);
            }

            foreach (var profile in persistence.Profiles)
            {
                UserProfileTransaction.ApplyChanges(profile, persistence.Id);
            }

            return true;
        }
    }
}
