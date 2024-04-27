using Mercure.Common.Persistence.Repository;
using Mercure.User.Domain.Aggregate.User;

namespace Mercure.User.Infrastructure.Persistence.Repository
{
    public interface IUserRepository : IRepository<UserAggregate>
    {
    }
}
