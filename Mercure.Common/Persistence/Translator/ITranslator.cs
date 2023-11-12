using Mercure.Common.Domain;
using Mercure.Common.Persistence.Model;

namespace Mercure.Common.Persistence.Translator
{
    public interface ITranslator<TAggregate, TPersistence>
        where TAggregate : IEntity
        where TPersistence : IEntityDB
    {
        TPersistence Translate(TAggregate aggregate);
        TAggregate Translate(TPersistence persistence);
    }
}
