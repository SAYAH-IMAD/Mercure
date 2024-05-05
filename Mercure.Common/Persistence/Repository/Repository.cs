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
        public ITranslator<TAggregate, TPersistence> Translator { get; private set; }
        public ITransaction<TPersistence> Transaction { get; private set; }

        public Repository(ITranslator<TAggregate, TPersistence> translator,
            ITransaction<TPersistence> transaction)
        {
            Translator = translator;
            Transaction = transaction;
        }

        public void Add(ref TAggregate aggregate)
        {
            TPersistence persistence = Translator.Translate(aggregate);
            Transaction.Insert(persistence);

            aggregate = Translator.Translate(persistence);
        }

        public TAggregate GetById(long identifier)
        {
            TAggregate aggregate = default;
            TPersistence persistence = Transaction.GetByIdentifier(identifier);

            if (persistence is not null)
                aggregate = Translator.Translate(persistence);

            return aggregate;
        }

        public bool Save(ref TAggregate aggregate)
        {
            TPersistence persistedData = Transaction.GetByIdentifier(aggregate.Identifier.Value);
            TPersistence updateData = Translator.Translate(aggregate);

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
                changeSaved = Transaction.ApplyChanges(tracked);
                changeTracking.AcceptChanges();
            }

            return changeSaved;
        }
    }
}
