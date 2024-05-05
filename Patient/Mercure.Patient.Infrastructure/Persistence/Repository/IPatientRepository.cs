using Mercure.Common.Persistence.Repository;
using Mercure.Patient.Domain.Aggregate;

namespace Mercure.Patient.Infrastructure.Persistence.Repository
{
    internal interface IPatientRepository : IRepository<PatientAggregate>
    {
    }
}
