using Mercure.Common.Domain;

namespace Mercure.Common.Persistence
{
    public interface IRepository<TAggregate>
        where TAggregate : IAggregate
    {
        TAggregate GetById(long identifier);
        void Add(ref TAggregate aggregate);
        bool Save(ref TAggregate aggregate);
    }
}
