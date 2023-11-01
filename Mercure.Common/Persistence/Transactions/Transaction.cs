namespace Mercure.Common.Persistence
{
    public abstract class Transaction<TPersistence> : ITransaction<TPersistence>
        where TPersistence : EntityDB<TPersistence>
    {
        public abstract bool Delete(TPersistence persistence, params object[] parentKeys);

        public abstract TPersistence GetByIdentifier(long identifier);

        public abstract List<TPersistence> GetByParentKey(params object[] parentKeys);

        public abstract bool Insert(TPersistence persistence, params object[] parentKeys);

        public abstract bool Update(TPersistence persistence, params object[] parentKeys);
    }
}
