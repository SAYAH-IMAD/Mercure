using MediatR;
using Mercure.User.Domain.Aggregate.Profile;
using Mercure.User.Infrastructure.Persistence.Repository;

namespace Mercure.User.Application.Commands
{
    public class ProfileCommandHandler : IRequestHandler<CreateProfileCommand>
    {
        readonly IProfileRepository _repository;

        public ProfileCommandHandler(IProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            ProfileAggregate profile = ProfileAggregate.Create(request.Profile.Title);

            _repository.Add(ref profile);
            _repository.Save(ref profile);
        }
    }
}
