using Mercure.Common.Persistence.Repository;
using Mercure.Common.Persistence.Transactions;
using Mercure.Common.Persistence.Translator;
using Mercure.Patient.Domain.Aggregate;
using Mercure.Patient.Infrastructure.Persistence.Model;

namespace Mercure.Patient.Infrastructure.Persistence.Repository
{
    public class PatientRepository : Repository<PatientAggregate, PatientModel>
    {
        public PatientRepository(ITranslator<PatientAggregate, PatientModel> translator, ITransaction<PatientModel> transaction) : base(translator, transaction)
        {
        }
    }
}
