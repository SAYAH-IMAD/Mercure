using Mercure.Common.Persistence.Model;
using Mercure.User.Domain.Enumerations;

namespace Mercure.User.Infrastructure.Persistence.Model
{
    public class RoleModel : EntityDB<RoleModel>
    {
        public virtual long? Id { get; set; }
        public virtual RoleEnumeration Code { get; set; }
        public virtual DateTime DateCreation { get; set; }

        public override string Identifier => Id.ToString();

        public override void Synchronise(RoleModel entity)
        {
            Id = entity.Id;
            Code = entity.Code;
            DateCreation = entity.DateCreation;
        }
    }
}
