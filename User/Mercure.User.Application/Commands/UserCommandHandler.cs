using MediatR;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Domain.ValueObject;
using Mercure.User.Infrastructure.Persistence;

namespace Mercure.User.Application.Commands
{
    internal class UserCommandHandler : IRequestHandler<CreateUserCommand>,
        IRequestHandler<AddProfileToUserCommand>
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
                new Address(request.User.Street, request.User.City, request.User.PostalCode), 
                request.User.BirthDate);

             _userRepository.Add(ref user);
             _userRepository.Save(ref user);
        }

        public async Task Handle(AddProfileToUserCommand request, CancellationToken cancellationToken)
        {
            UserAggregate user = _userRepository.GetById(request.UserProfile.UserId);
            
            //Profile profile = Profile.Create(request.UserProfile.Title);
           // user.AddProfile(profile);

            _userRepository.Save(ref user);

        }
    }
}
