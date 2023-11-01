using Mercure.Common.Persistence;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Infrastructure.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Translator
{
    internal class UserProfileTranslator : ITranslator<UserProfile, UserProfileModel>
    {
        public UserProfileModel Translate(UserProfile aggregate) 
            => new() { Id = aggregate.Identifier, CreationDate = aggregate.CreationDate, ProfileId = aggregate.ProfileId };

        public UserProfile Translate(UserProfileModel persistence) 
            => new(persistence.Id ,persistence.ProfileId, persistence.CreationDate);
    }
}
