using MediatR;
using Mercure.User.Application.Queries.Models;

namespace Mercure.User.Application.Queries
{
    public class RegisterUserQuery : IRequest<RegisterUserQueryModel>
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public RegisterUserQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
