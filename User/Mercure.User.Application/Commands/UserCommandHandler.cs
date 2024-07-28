using MediatR;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Domain.ValueObject;
using Mercure.User.Infrastructure.Persistence.Repository;

namespace Mercure.User.Application.Commands
{
    internal class UserCommandHandler : IRequestHandler<CreateUserCommand>,
        IRequestHandler<AssignProfileToUserCommand>,
        IRequestHandler<UpdateUserCommand>

    {
        readonly IUserRepository _repository;

        public UserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserAggregate user = UserAggregate.Create(request.User.FirstName,
                request.User.LastName,
                new Email(request.User.Email),
                new Password(request.User.Password),
                new Address(request.User.Street, request.User.City, request.User.PostalCode),
                request.User.BirthDate);

            _repository.Add(ref user);
            _repository.Save(ref user);
        }

        public async Task Handle(AssignProfileToUserCommand request, CancellationToken cancellationToken)
        {
            UserAggregate user = _repository.GetById(request.UserProfile.UserId);

            user.AssignProfile(UserProfile.Create(request.UserProfile.ProfileId, DateTime.Now));

            _repository.Save(ref user);
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            UserAggregate user = _repository.GetById(request.User.UserId);

            user.UpdateEmail(new Email(request.User.Email));
            user.UpdateAddress(new Address(request.User.Street, request.User.City, request.User.PostalCode));

            _repository.Save(ref user);
        }
    }
}
