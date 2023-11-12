using ChangeTracking;
using Mercure.Common.Domain;
using Mercure.Common.Extension;
using Mercure.Common.Persistence.Model;
using Mercure.Common.Persistence.Transactions;
using Mercure.Common.Persistence.Translator;

namespace Mercure.Common.Persistence.Repository
{
    public abstract class Repository<TAggregate, TPersistence> : IRepository<TAggregate>
        where TAggregate : IAggregateRoot
        where TPersistence : EntityDB<TPersistence>
    {
        readonly ITranslator<TAggregate, TPersistence> _translator;
        readonly ITransaction<TPersistence> _transaction;

        public Repository(ITranslator<TAggregate, TPersistence> translator,
            ITransaction<TPersistence> transaction)
        {
            _translator = translator;
            _transaction = transaction;
        }

        public void Add(ref TAggregate aggregate)
        {
            TPersistence persistence = _translator.Translate(aggregate);
            _transaction.Insert(persistence);

            aggregate = _translator.Translate(persistence);
        }

        public TAggregate GetById(long identifier)
        {
            TAggregate aggregate = default;
            TPersistence persistence = _transaction.GetByIdentifier(identifier);

            if (persistence is not null)
                aggregate = _translator.Translate(persistence);

            return aggregate;
        }

        public bool Save(ref TAggregate aggregate)
        {
            TPersistence persistedData = _transaction.GetByIdentifier(aggregate.Identifier.Value);
            TPersistence updateData = _translator.Translate(aggregate);

            bool changeSaved = SaveChanges(persistedData, updateData);

            return changeSaved;
        }

        private bool SaveChanges(TPersistence original, TPersistence update)
        {
            bool changeSaved = false;

            TPersistence tracked = original.AsTrackable();

            tracked.Synchronise(update);

            IChangeTrackable<TPersistence> changeTracking = tracked.CastToIChangeTrackable();

            if (changeTracking.IsChanged)
            {
                changeSaved = _transaction.ApplyChanges(tracked);
                changeTracking.AcceptChanges();
            }

            return changeSaved;
        }
    }
}
