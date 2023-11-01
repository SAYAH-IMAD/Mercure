using Mercure.Common.Domain;

namespace Mercure.User.Domain.Enumerations
{
    public class RoleEnumeration : Enumeration
    {
        public static readonly RoleEnumeration Administrator = new("ADMIN", nameof(Administrator));
        public static readonly RoleEnumeration Public = new("PUBLI", nameof(Public));

        public RoleEnumeration(string code, string name) 
            : base(code, name)
        {
        }
    }
}
