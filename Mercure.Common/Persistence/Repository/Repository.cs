using ChangeTracking;
using Mercure.Common.Domain;

namespace Mercure.Common.Persistence
{
    public abstract class Repository<TAggregate, TPersistence> : IRepository<TAggregate>
        where TAggregate : IAggregate
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
            bool status = _transaction.Insert(persistence);
            
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
            TPersistence persistedData =  _transaction.GetByIdentifier(aggregate.Identifier.Value);
            TPersistence updateData = _translator.Translate(aggregate);

            bool changeSaved = SaveChanges(persistedData, updateData);

            return changeSaved;
        }

        private bool SaveChanges(TPersistence persistedData, TPersistence updateData)
        {
            bool changeSaved = false;

            persistedData.Synchronise(updateData);
           
            IChangeTrackable<TPersistence> changeTracking = persistedData.AsTrackable()
                .CastToIChangeTrackable();

            if (changeTracking.IsChanged)
            {
                changeSaved = _transaction.Update(persistedData);
                changeTracking.AcceptChanges();
            }

            return changeSaved;
        }
    }
}
