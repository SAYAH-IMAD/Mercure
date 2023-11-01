using Mercure.Common.Persistence;
using Mercure.User.Domain.Aggregate.User;

namespace Mercure.User.Infrastructure.Persistence
{
    internal class UserRepository : Repository<UserAggregate, UserModel>, IUserRepository
    {
        public UserRepository(ITranslator<UserAggregate, UserModel> translator, ITransaction<UserModel> entity)
            : base(translator, entity)
        {
        }
    }
}
