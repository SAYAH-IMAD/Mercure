using MediatR;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Domain.Enumerations;
using Mercure.User.Domain.ValueObject;
using Mercure.User.Infrastructure.Persistence.Repository;

namespace Mercure.User.Application.Commands
{
    internal class UserCommandHandler : IRequestHandler<CreateUserCommand>,
        IRequestHandler<AssignProfileToUserCommand>

    {
        readonly IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserAggregate user = UserAggregate.Create(request.User.FirstName, 
                request.User.LastName, 
                new Email(request.User.Email),
                new Password(request.User.Password),
                new Address(request.User.Street, request.User.City, request.User.PostalCode), 
                request.User.BirthDate);

             _userRepository.Add(ref user);
             _userRepository.Save(ref user);
        }

        public async Task Handle(AssignProfileToUserCommand request, CancellationToken cancellationToken)
        {
            UserAggregate user = _userRepository.GetById(request.UserProfile.UserId);
          
            user.AssignProfile(UserProfile.Create(request.UserProfile.ProfileId, DateTime.Now));
            user.AssignState(UserStateEnumeration.Active, DateTime.Now);

            _userRepository.Save(ref user);
        }

    }
}
