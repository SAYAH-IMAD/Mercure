namespace Mercure.Common.Persistence
{
    public interface ITransaction<TPersistence>
        where TPersistence : IEntityDB
    {
        bool Delete(TPersistence persistence, params object[] parentKeys);

        TPersistence GetByIdentifier(long identifier);

        List<TPersistence> GetByParentKey(params object[] parentKeys);

        bool Insert(TPersistence persistence, params object[] parentKeys);

        bool Update(TPersistence persistence, params object[] parentKeys);
    }
}
