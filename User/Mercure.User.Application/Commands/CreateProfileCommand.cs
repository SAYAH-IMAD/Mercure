using MediatR;

namespace Mercure.User.Application.Commands
{
    public class CreateProfileCommand : IRequest
    {
        public ProfileCommandModel Profile { get; private set; }

        public CreateProfileCommand(ProfileCommandModel profile)
        {
            Profile = profile;
        }
    }
}
