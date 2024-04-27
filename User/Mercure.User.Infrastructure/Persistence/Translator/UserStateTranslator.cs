using Mercure.Common.Persistence.Translator;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Infrastructure.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Translator
{
    internal class UserStateTranslator : ITranslator<UserState, UserStateModel>
    {
        public UserStateModel Translate(UserState aggregate)
            => new() { Id = aggregate.Identifier, Code = aggregate.State, CreationDate = aggregate.CreationDate };

        public UserState Translate(UserStateModel persistence)
            => new(persistence.Id, persistence.Code, persistence.CreationDate);
    }
}
