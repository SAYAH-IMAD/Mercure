using Mercure.Common.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Model
{
    public class ProfileModel : EntityDB<ProfileModel>
    {
        public virtual long? Id { get; set; }
        public virtual string Title { get; set; }
        public virtual List<RoleModel> HistoryRole { get; set; }

        public override string Identifier => Id.ToString();

        public override void Synchronise(ProfileModel entity)
        {
            Id = entity.Id;
            Title = entity.Title;

            SynchroniseRelation(HistoryRole, entity.HistoryRole);
        }
    }
}
