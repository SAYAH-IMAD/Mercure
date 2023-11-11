using ChangeTracking;
using Mercure.Common.Persistence;

namespace Mercure.Common.Extension
{
    public static class TransactionExtension
    {
        public static bool ApplyChanges<TPersistence>(this ITransaction<TPersistence> transaction, TPersistence persistence, long? parentKey) 
            where TPersistence : IEntityDB
        { 
            if(transaction == null) throw new ArgumentNullException(nameof(transaction));

            IChangeTrackable<TPersistence> changeTracking = (IChangeTrackable<TPersistence>) persistence;

            if (changeTracking.ChangeTrackingStatus == ChangeStatus.Added) 
            {
                transaction.Insert(persistence, parentKey);
            }
            if (changeTracking.ChangeTrackingStatus == ChangeStatus.Changed)
            {
                transaction.Update(persistence, parentKey);
            }
            if (changeTracking.ChangeTrackingStatus == ChangeStatus.Deleted)
            {
                transaction.Delete(persistence, parentKey);
            }

            return true;
        }
    }
}
