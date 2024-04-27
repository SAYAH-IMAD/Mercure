using Mercure.Common.Interface;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Domain.ValueObject;

namespace Mercure.User.Domain.Test.Builder
{
    internal class UserBuilder : IBuilder<UserAggregate>
    {
        string _firstName;
        string _lastName;
        string _email;
        string _password;
        Address _address;
        DateTime _birthDate;
        List<UserState> _userStatus;
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

        public UserBuilder WithEmail(string email)
        {
            _email = email;

            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            _password = password;

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
            return new UserAggregate(null, 
                _firstName, 
                _lastName, 
                _email,
                _password,
                _address, 
                _birthDate, 
                _userStatus, 
                _userProfile);
        }
    }
}
