using Mercure.Common.Domain;

namespace Mercure.Common.Persistence
{
    public interface ITranslator<TAggregate, TPersistence>
        where TAggregate : IEntity
        where TPersistence : IEntityDB
    {
        TPersistence Translate(TAggregate aggregate);
        TAggregate Translate(TPersistence persistence);
    }
}
