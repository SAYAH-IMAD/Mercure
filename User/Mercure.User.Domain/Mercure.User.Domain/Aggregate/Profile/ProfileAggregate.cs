using Mercure.Common.Domain;
using Mercure.User.Domain.Enumerations;

namespace Mercure.User.Domain.Aggregate.Profile
{
    public class ProfileAggregate : AggregateRoot
    {
        public ProfileAggregate(long? id, 
            string title, 
            List<Role> roles)
            :base(id)
        {
            Title = title;
            Roles = roles;
        }

        public string Title { get; private set; }
        public ICollection<Role> Roles { get; private set; }

        public static ProfileAggregate Create(string title) => new
            (null, title, new List<Role>());

        public void AssignRole(RoleEnumeration role, DateTime date)
        {
            Roles.Add(Role.Create(role, date));
        }
    }
}
