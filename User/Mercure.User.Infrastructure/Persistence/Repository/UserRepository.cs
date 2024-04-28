using Mercure.Common.Persistence.Repository;
using Mercure.Common.Persistence.Transactions;
using Mercure.Common.Persistence.Translator;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Infrastructure.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Repository
{
    internal class UserRepository : Repository<UserAggregate, UserModel>, IUserRepository
    {

        public UserRepository(ITranslator<UserAggregate, UserModel> translator, ITransaction<UserModel> entity)
            : base(translator, entity)
        {
        }
    }
}
