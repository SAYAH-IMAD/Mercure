using Mercure.Common.Domain;

namespace Mercure.User.Domain.Enumerations
{
    public class UserStateEnumeration : Enumeration
    {
        public static readonly UserStateEnumeration Active = new("ACTI", nameof(Active));
        public static readonly UserStateEnumeration Inactive = new("INACT", nameof(Inactive));

        public UserStateEnumeration(string code, string value) 
            : base(code, value)
        {
        }
    }
}
