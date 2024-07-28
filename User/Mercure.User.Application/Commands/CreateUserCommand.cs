using MediatR;

namespace Mercure.User.Application.Commands
{
    public class CreateUserCommand : IRequest
    {
        public UserCommandModel User { get; private set; }

        public CreateUserCommand(UserCommandModel user)
        {
            User = user;
        }
    }
}
