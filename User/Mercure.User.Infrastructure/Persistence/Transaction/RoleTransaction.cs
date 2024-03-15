using Mercure.Common.Persistance;
using Mercure.Common.Persistence.Transactions;
using Mercure.User.Infrastructure.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Transaction
{
    internal class RoleTransaction : ITransaction<RoleModel>
    {
        public IAccessDB Access => throw new NotImplementedException();

        public bool Delete(RoleModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public RoleModel GetByIdentifier(long identifier)
        {
            throw new NotImplementedException();
        }

        public List<RoleModel> GetByParentKey(params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public bool Insert(RoleModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }

        public bool Update(RoleModel persistence, params object[] parentKeys)
        {
            throw new NotImplementedException();
        }
    }
}
