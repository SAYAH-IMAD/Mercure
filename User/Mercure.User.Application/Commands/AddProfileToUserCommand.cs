using MediatR;

namespace Mercure.User.Application.Commands
{
    public class AddProfileToUserCommand : IRequest
    {
        public UserProfileCommandModel UserProfile { get; private set; }

        public AddProfileToUserCommand(UserProfileCommandModel userProfile)
        {
            UserProfile = userProfile;
        }
    }
}
