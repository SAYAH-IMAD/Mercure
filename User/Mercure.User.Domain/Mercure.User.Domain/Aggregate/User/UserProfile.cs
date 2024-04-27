using Mercure.Common.Domain;

namespace Mercure.User.Domain.Aggregate.User
{
    public class UserProfile : IEntity
    {
        public UserProfile(long? identifier,
            long profileId,
            DateTime dateCreation)
        {
            Identifier = identifier;
            ProfileId = profileId;
            CreationDate = dateCreation;
        }

        public long? Identifier { get; set; }
        public long ProfileId { get; set; }
        public DateTime CreationDate { get; private set; }

        public static UserProfile Create(long profileId, DateTime dateCreation)
            => new(null, profileId, dateCreation);
    }
}
