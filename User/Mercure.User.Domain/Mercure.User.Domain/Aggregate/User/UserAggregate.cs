using Mercure.Common.Domain;
using Mercure.User.Domain.Enumerations;
using Mercure.User.Domain.Exceptions;
using Mercure.User.Domain.ValueObject;

namespace Mercure.User.Domain.Aggregate.User
{
    public class UserAggregate : AggregateRoot
    {
        public UserAggregate(long? id,
            string firstName,
            string lastName,
            Email email,
            Password password,
            Address address,
            DateTime birthDate,
            List<UserState> historyStates,
            List<UserProfile> profiles) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Address = address;
            BirthDate = birthDate;
            HistoryStates = historyStates;
            Profiles = profiles;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public Address Address { get; private set; }
        public DateTime BirthDate { get; private set; }
        public ICollection<UserProfile> Profiles { get; private set; }
        public ICollection<UserState> HistoryStates { get; private set; }

        public static UserAggregate Create(string firstName,
            string lastName,
            Email email,
            Password password,
            Address address,
            DateTime birthDate)
            => new(null, firstName, lastName, email, password, address, birthDate, new List<UserState>(), new List<UserProfile>());

        public void AssignProfile(UserProfile profile)
        {
            if (Profiles.Any(e => e.ProfileId == profile.ProfileId))
                throw new AssignProfileException();
            else
                Profiles.Add(profile);
        }

        public void RemoveProfile(UserProfile profile)
        {
            if (Profiles.Any(e => e.ProfileId == profile.ProfileId))
                Profiles.Remove(profile);
            else
                throw new RemoveProfileException();
        }

        public void AssignState(UserStateEnumeration state, DateTime date)
        {
            HistoryStates.Add(UserState.Create(state, date));
        }
    }
}
