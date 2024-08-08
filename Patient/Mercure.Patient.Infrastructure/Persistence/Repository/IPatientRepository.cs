using Mercure.Common.Persistence.Repository;
using Mercure.Patient.Domain.Aggregate;

namespace Mercure.Patient.Infrastructure.Persistence.Repository
{
    public interface IPatientRepository : IRepository<PatientAggregate>
    {
    }
}
