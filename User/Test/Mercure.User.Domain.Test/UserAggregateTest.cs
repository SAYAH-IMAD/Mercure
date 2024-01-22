using FluentAssertions;
using Mercure.Common.Exceptions;
using Mercure.User.Domain.Aggregate;
using Mercure.User.Domain.Test.Builder;
using Mercure.User.Domain.ValueObject;

namespace Mercure.User.Domain.Test
{
    public class UserAggregateTest
    {

        [Fact]
        public void CreateUser_BasicUser_ReturnUser()
        {
            //Arrange
            string firstName = "Imad";
            string lastName = "SAYAH";
            Address address = new("King Street", "California", "G1E 0M2");
            DateTime birthDate = new(2024, 01, 01);
            
            //Act
            var user = UserAggregate.Create(firstName, 
                lastName, 
                address, 
                birthDate);

            //Assert
            user.FirstName.Should().Be(firstName);
            user.LastName.Should().Be(lastName);
            user.Address.Should().Be(address);    
            user.BirthDate.Should().Be(birthDate);
        }

        [Fact]
        public void AssignProfile__AssignsProfileToUser()
        {
            //Arrange

            UserAggregate user = new UserBuilder()
                .WithFirstName("Imad")
                .WithLastName("SAYAH")
                .WithAddress(new("King Street", "California", "G1E 0M2"))
                .WithBirthDate(new(2024, 01, 01))
                .Build();

            UserProfile profile = new UserProfileBuilder()
                .WithProfileId(1)
                .WithDateCreation(new(2024, 01, 01))
                .Build();

            //Act
            user.AssignProfile(profile);

            //Assert
            user.Profiles.Should().HaveCount(1);
            user.Profiles.Should().Contain(profile);
        }

        [Fact]
        public void AssignProfile__ThrowFunctionException()
        {
            //Arrange

            UserProfile profile = new UserProfileBuilder()
                .WithProfileId(1)
                .WithDateCreation(new(2024, 01, 01))
                .Build();

            UserAggregate user = new UserBuilder()
                 .WithFirstName("Imad")
                 .WithLastName("SAYAH")
                 .WithAddress(new("King Street", "California", "G1E 0M2"))
                 .WithBirthDate(new(2024, 01, 01))
                 .Build();

            //Act
            Action assignProfile = () => user.AssignProfile(profile);

            //Assert
            assignProfile.Should().Throw<FunctionalException>();
        }
    }
}