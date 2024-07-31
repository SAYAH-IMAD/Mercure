using Mercure.Common.Persistence.Repository;
using Mercure.User.Domain.Aggregate.Profile;

namespace Mercure.User.Infrastructure.Persistence.Repository
{
    public interface IProfileRepository : IRepository<ProfileAggregate>
    {
    }
}
