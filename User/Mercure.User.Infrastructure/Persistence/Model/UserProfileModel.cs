using Mercure.Common.Persistence;

namespace Mercure.User.Infrastructure.Persistence.Model
{
    public class UserProfileModel : EntityDB<UserProfileModel>
    {
        public virtual long? Id { get; set; }
        public virtual long ProfileId { get; set; }
        public virtual DateTime CreationDate { get; set; }

        public override string Identifier => Id.ToString();

        public override void Synchronise(UserProfileModel entity)
        {
            Id = entity.Id;
            ProfileId = entity.ProfileId;
            CreationDate = entity.CreationDate;
        }
    }
}
