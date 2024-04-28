using MediatR;
using Mercure.User.Application.Commands.Models;

namespace Mercure.User.Application.Commands
{
    public class AssignProfileToUserCommand : IRequest
    {
        public UserProfileCommandModel UserProfile { get; private set; }

        public AssignProfileToUserCommand(UserProfileCommandModel userProfile)
        {
            UserProfile = userProfile;
        }
    }
}
