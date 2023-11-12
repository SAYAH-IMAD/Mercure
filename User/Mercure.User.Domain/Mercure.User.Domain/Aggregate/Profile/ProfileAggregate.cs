using Mercure.Common.Domain;
using Mercure.User.Domain.Enumerations;

namespace Mercure.User.Domain.Aggregate
{
    public class ProfileAggregate : IEntity
    {
        public ProfileAggregate(long? identifier, string title, List<Role> historyRole)
        {
            Identifier = identifier;
            Title = title;
            HistoryRole = historyRole;
        }

        public long? Identifier { get; set; }
        public string Title { get; private set; }
        public ICollection<Role> HistoryRole { get; private set; }

        public static ProfileAggregate Create(string title) => new
            (null, title, new List<Role>());

        public void AssignRole(RoleEnumeration role, DateTime date)
        {
            HistoryRole.Add(Role.Create(role, date));
        }
    }
}
