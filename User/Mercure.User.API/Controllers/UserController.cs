using MediatR;
using Mercure.Common;
using Mercure.User.Application.Commands;
using Mercure.User.Application.Commands.Models;
using Mercure.User.Application.Queries;
using Mercure.User.Application.Queries.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercure.User.API.Controllers
{
    [ApiController]
    [Route("API/User/V1")]
    public class UserController : ControllerBasic
    {
        public UserController(IMediator mediator)
            : base(mediator)
        {
        }

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
    }
}
