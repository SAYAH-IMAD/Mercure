using Mercure.Common.Persistence;
using Mercure.User.Domain.Aggregate.User;

namespace Mercure.User.Infrastructure.Persistence
{
    internal class UserStateTranslator : ITranslator<UserState, UserStateModel>
    {
        public UserStateModel Translate(UserState aggregate) 
            => new() { Id = aggregate.Identifier.Value, Code = aggregate.State, CreationDate = aggregate.CreationDate };

        public UserState Translate(UserStateModel persistence) 
            => new(persistence.Id, persistence.Code, persistence.CreationDate);
    }
}
