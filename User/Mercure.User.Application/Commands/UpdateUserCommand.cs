using MediatR;

namespace Mercure.User.Application.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public UserCommandModel User { get; private set; }

        public UpdateUserCommand(UserCommandModel user)
        {
            User = user;
        }
    }
}
