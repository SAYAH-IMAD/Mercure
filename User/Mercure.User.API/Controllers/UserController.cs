using MediatR;
using Mercure.Common;
using Mercure.User.Application.Commands;
using Mercure.User.Application.Commands.Models;
using Mercure.User.Application.Queries;
using Mercure.User.Application.Queries.Models;
using Mercure.User.Application.Queries.Profile;
using Mercure.User.Application.Queries.Profile.Models;
using Mercure.User.Infrastructure.Security.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercure.User.API.Controllers
{
    [ApiController]
    [Route("API/User/V1")]
    public class UserController : ControllerBasic
    {
        readonly ITokenProvider _token;
        public UserController(IMediator mediator, ITokenProvider token)
            : base(mediator)
        {
            _token = token;
        }

        [Authorize]
        [HttpGet("GetUsers")]
        public async Task<IEnumerable<UserQueryModel>> GetUsers() =>
          await Mediator.Send(new GetUsersQuery());

        [Authorize]
        [HttpGet("GetUser")]
        public async Task<UserQueryModel> GetUser(int id) =>
            await Mediator.Send(new GetUserQuery(id));

        [HttpPost("CreateUser")]
        public async Task CreateUser(UserCommandModel user) =>
            await Mediator.Send(new CreateUserCommand(user));

        [HttpPost("AssignProfile")]
        public async Task AssignProfile(UserProfileCommandModel user) =>
            await Mediator.Send(new AssignProfileToUserCommand(user));

        [HttpPost("Authenticate")]
        public async Task<TokenQueryModel> Authenticate(string email, string password)
        {
            RegisterUserQueryModel user = await Mediator.Send(new RegisterUserQuery(email, password));
            IEnumerable<ProfileQueryModel> profiles = await Mediator.Send(new GetProfileQuery(user.id));

            if (user is not null)
            {
                return new TokenQueryModel() 
                { 
                    AccesToken = _token.GenerateToken(user.id, user.Email, profiles.Select(e => e.Name).ToList(), null)
                };
            }
            else 
                throw new ArgumentNullException(nameof(user));
        }

    }
}
