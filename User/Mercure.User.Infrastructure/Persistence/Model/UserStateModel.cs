using Mercure.Common.Persistence;
using Mercure.User.Domain.Enumerations;

namespace Mercure.User.Infrastructure.Persistence
{
    public class UserStateModel : EntityDB<UserStateModel>
    {
        public virtual long? Id { get; set; }
        public virtual UserStateEnumeration Code { get; set; }
        public virtual DateTime CreationDate { get;  set; }

        public override string Identifier => Id.ToString();

        public override void Synchronise(UserStateModel entity)
        {
            Id = entity.Id;
            Code = entity.Code;
            CreationDate = entity.CreationDate;
        }
    }
}
