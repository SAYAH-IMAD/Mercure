using FluentAssertions;
using Mercure.Common.Persistence.Transactions;
using Mercure.Common.Persistence.Translator;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Domain.ValueObject;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Repository;
using Moq;

namespace Mercure.User.Infrastructure.Test
{
    public class UserRepositoryTest
    {
        readonly Mock<ITranslator<UserAggregate, UserModel>> _translatorMock;
        readonly Mock<ITransaction<UserModel>> _transactionMock;

        public UserRepositoryTest()
        {
            _transactionMock = new Mock<ITransaction<UserModel>>();
            _translatorMock = new Mock<ITranslator<UserAggregate, UserModel>>();
        }

        [Fact]
        public void Add_Always_AddUser()
        {
            //Arrange
            string firstName = "Imad";
            string lastName = "SAYAH";
            string email = "email";
            string password = "password";
            Address address = new("King Street", "California", "G1E 0M2");
            DateTime birthDate = new(2024, 01, 01);

            UserAggregate aggregate = UserAggregate.Create(firstName,
                lastName,
                email,
                password,
                address,
                birthDate);

            _translatorMock.Setup(e => e.Translate(It.IsAny<UserAggregate>()))
                .Returns(It.IsAny<UserModel>());

            _translatorMock.Setup(e => e.Translate(It.IsAny<UserModel>()))
                .Returns(It.IsAny<UserAggregate>());

            // Act 
            new UserRepository(_translatorMock.Object, _transactionMock.Object)
            .Add(ref aggregate);

            // Assert

            _transactionMock.Verify(e => e.Insert(It.IsAny<UserModel>()));
            _translatorMock.Verify(e => e.Translate(It.IsAny<UserAggregate>()));
            _translatorMock.Verify(e => e.Translate(It.IsAny<UserModel>()));
        }

        [Fact]
        public void GetById_Always_ReturnUser()
        {
            //Arrange
            int id = 1;
            string firstName = "Imad";
            string lastName = "SAYAH";
            string email = "email";
            string password = "password";
            Address address = new("King Street", "California", "G1E 0M2");
            DateTime birthDate = new(2024, 01, 01);

            UserAggregate aggregate = UserAggregate.Create(firstName,
                lastName,
                email,
                password,
                address,
                birthDate);

            _translatorMock.Setup(e => e.Translate(It.IsAny<UserAggregate>()))
                .Returns(It.IsAny<UserModel>());

            _translatorMock.Setup(e => e.Translate(It.IsAny<UserModel>()))
                .Returns(It.IsAny<UserAggregate>());

            // Act 
            UserAggregate result = new UserRepository(_translatorMock.Object, _transactionMock.Object)
             .GetById(id);

            // Assert
            result.Should().Be(aggregate);
        }

        [Fact]
        public void Save_Always_SaveChanges()
        {
            //Arrange
            int id = 1;
            string firstName = "Imad";
            string lastName = "SAYAH";
            string email = "email";
            string password = "password";
            Address address = new("King Street", "California", "G1E 0M2");
            DateTime birthDate = new(2024, 01, 01);

            UserAggregate aggregate = new(id,
                firstName,
                lastName,
                email,
                password,
                address,
                birthDate,
                [],
                []);

            UserModel model = new()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                BirthDate = birthDate,
                City = "",
                Street = "",
                PostalCode = "12345",
                Profiles = [],
                HistoryStates = []
            };

            _transactionMock.Setup(e => e.GetByIdentifier(aggregate.Identifier.Value))
                .Returns(model);

            _translatorMock.Setup(e => e.Translate(aggregate))
                .Returns(model);

            _translatorMock.Setup(e => e.Translate(model))
                .Returns(aggregate);

            // Act 
            new UserRepository(_translatorMock.Object, _transactionMock.Object)
             .Save(ref aggregate);

            // Assert
        }
    }
}