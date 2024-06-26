﻿using Mercure.Common.Persistence.DataReader;
using Mercure.Common.Persistence.Transactions;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Query;

namespace Mercure.User.Infrastructure.Persistence.Transaction
{
    public class UserProfileTransaction : ITransaction<UserProfileModel>
    {
        readonly IDBContext _context;

        public UserProfileTransaction(IDBContext context)
        {
            _context = context;
        }

        public IDBContext Context => _context;

        public bool Delete(UserProfileModel persistence, params object[] parentKeys)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id}
            };

            _context.Execute(UserProfileQueries.Delete, parameters);

            return true;
        }

        public UserProfileModel GetByIdentifier(long identifier)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@ID", identifier}
            };

            var result = _context.ReadFirst<UserProfileModel>(UserProfileQueries.GetById, parameters);

            return result;
        }

        public List<UserProfileModel> GetByParentKey(params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;

            Dictionary<string, object> parameters = new()
            {
                { "@USER_ID",userId},
            };

            var result = _context.Read<UserProfileModel>(UserProfileQueries.GetByParentKey, parameters).ToList();

            return result;
        }

        public bool Insert(UserProfileModel persistence, params object[] parentKeys)
        {
            long? userId = parentKeys[0] as long?;
            persistence.Id = _context.GetSequence("USER_PROFILE_ID");

            Dictionary<string, object> parameters = new()
            {
                { "@ID", persistence.Id},
                { "@CREATION_DATE",persistence.CreationDate},
                { "@PROFILE_ID",persistence.ProfileId},
                { "@USER_ID",userId},
            };

            _context.Execute<UserProfileModel>(UserProfileQueries.Insert, parameters);

            return true;
        }

        public bool Update(UserProfileModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }
    }
}
