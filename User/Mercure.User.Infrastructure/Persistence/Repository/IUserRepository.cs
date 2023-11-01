using Mercure.Common.Persistence;
using Mercure.User.Domain.Aggregate.User;

namespace Mercure.User.Infrastructure.Persistence
{
    public interface IUserRepository : IRepository<UserAggregate>
    {
    }
}
