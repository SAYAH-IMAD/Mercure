using Mercure.Common.Test;
using Mercure.User.Domain.Aggregate;
using Mercure.User.Domain.ValueObject;

namespace Mercure.User.Domain.Test.Builder
{
    internal class UserBuilder : IBuilder<UserAggregate>
    {
        string _firstName;
        string _lastName;
        Address _address;
        DateTime _birthDate;
        List<UserProfile> _userProfile;

        public UserBuilder WithFirstName(string firstName) 
        { 
            _firstName = firstName;

            return this;
        }

        public UserBuilder WithLastName(string lastName) 
        { 
            _lastName = lastName;

            return this;
        }

        public UserBuilder WithAddress(Address address) 
        { 
            _address = address;

            return this;
        }

        public UserBuilder WithBirthDate(DateTime birthDate) 
        {
            _birthDate = birthDate;

            return this;
        }


        public UserAggregate Build()
        {
            return new UserAggregate(this);
        }
    }
}
