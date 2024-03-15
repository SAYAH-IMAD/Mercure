using Mercure.Common.Persistance;
using Mercure.Common.Persistence.Model;

namespace Mercure.Common.Persistence.Transactions
{
    public abstract class Transaction<TPersistence> : ITransaction<TPersistence>
        where TPersistence : EntityDB<TPersistence>
    {
        public abstract IAccessDB Access { get; }

        public abstract bool Delete(TPersistence persistence, params object[] parentKeys);

        public abstract TPersistence GetByIdentifier(long identifier);

        public abstract List<TPersistence> GetByParentKey(params object[] parentKeys);

        public abstract bool Insert(TPersistence persistence, params object[] parentKeys);

        public abstract bool Update(TPersistence persistence, params object[] parentKeys);
    }
}
