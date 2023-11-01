using Mercure.Common.Domain;
using Mercure.User.Domain.Enumerations;

namespace Mercure.User.Domain.Aggregate.User
{
    public class UserState : IEntity
    {
        public UserState(long? identifier,
            UserStateEnumeration state,
            DateTime dateCreation)
        {
            Identifier = identifier;
            State = state;
            CreationDate = dateCreation;
        }

        public long? Identifier { get; set; }
        public UserStateEnumeration State { get; private set; }
        public DateTime CreationDate { get; private set; }

        public static UserState Create(UserStateEnumeration state, DateTime dateCreation)
            => new(null, state, dateCreation);
    }
}
