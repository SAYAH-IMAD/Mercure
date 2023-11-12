using Mercure.Common.Domain;

namespace Mercure.Common.Persistence.Repository
{
    public interface IRepository<TAggregate>
        where TAggregate : IAggregateRoot
    {
        TAggregate GetById(long identifier);
        void Add(ref TAggregate aggregate);
        bool Save(ref TAggregate aggregate);
    }
}
