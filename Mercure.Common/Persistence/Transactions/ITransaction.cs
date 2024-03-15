using Mercure.Common.Persistence.DataReader;
using Mercure.Common.Persistence.Model;

namespace Mercure.Common.Persistence.Transactions
{
    public interface ITransaction<TPersistence>
        where TPersistence : IEntityDB
    {
        public IAccessDB Access { get; }

        bool Delete(TPersistence persistence, params object[] parentKeys);

        TPersistence GetByIdentifier(long identifier);

        List<TPersistence> GetByParentKey(params object[] parentKeys);

        bool Insert(TPersistence persistence, params object[] parentKeys);

        bool Update(TPersistence persistence, params object[] parentKeys);
    }
}
