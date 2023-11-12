using Mercure.Common.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Model
{
    public class UserModel : EntityDB<UserModel>
    {
        public virtual long? Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual IList<UserStateModel> HistoryStates { get; set; }
        public virtual IList<UserProfileModel> Profiles { get; set; }

        public override string Identifier => Id.ToString();

        public override void Synchronise(UserModel entity)
        {
            Id = entity.Id;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Street = entity.Street;
            City = entity.City;
            PostalCode = entity.PostalCode;
            BirthDate = entity.BirthDate;

            SynchroniseRelation(Profiles, entity.Profiles);
            SynchroniseRelation(HistoryStates, entity.HistoryStates);
        }
    }
}
