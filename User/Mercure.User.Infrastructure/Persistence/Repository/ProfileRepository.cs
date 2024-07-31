using Mercure.Common.Persistence.Repository;
using Mercure.Common.Persistence.Transactions;
using Mercure.Common.Persistence.Translator;
using Mercure.User.Domain.Aggregate.Profile;
using Mercure.User.Infrastructure.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Repository
{
    internal class ProfileRepository : Repository<ProfileAggregate, ProfileModel>, IProfileRepository
    {
        public ProfileRepository(ITranslator<ProfileAggregate, ProfileModel> translator, ITransaction<ProfileModel> transaction) 
            : base(translator, transaction)
        {
        }
    }
}
