using Mercure.Common.Domain;
using Mercure.User.Domain.Enumerations;

namespace Mercure.User.Domain.Aggregate
{
    public class Role : IEntity
    {
        public Role(long? identifier,
           RoleEnumeration code,
           DateTime dateCreation)
        {
            Identifier = identifier;
            Code = code;
            DateCreation = dateCreation;
        }

        public long? Identifier { get; set; }
        public RoleEnumeration Code { get; private set; }
        public DateTime DateCreation { get; private set; }

        public static Role Create(RoleEnumeration code, DateTime dateCreation)
            => new(null, code, dateCreation);
    }
}
