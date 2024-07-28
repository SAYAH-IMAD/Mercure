using MediatR;
using Mercure.Common;
using Mercure.User.Application.Commands;
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

        [HttpGet("GetUsers", Name = "GetUsers")]
        public async Task<IEnumerable<UserQueryModel>> GetUsers() =>
            await Mediator.Send(new GetUsersQuery());

        [HttpGet("GetUser", Name = "GetUser")]
        public async Task<UserQueryModel> GetUser(int id) =>
            await Mediator.Send(new GetUserQuery(id));

        [HttpPost("CreateUser", Name = "CreateUser")]
        public async Task CreateUser(UserCommandModel user) =>
            await Mediator.Send(new CreateUserCommand(user));

        [HttpPost("AssignProfile", Name = "AssignProfile")]
        public async Task AssignProfile(UserProfileCommandModel user) =>
            await Mediator.Send(new AssignProfileToUserCommand(user));

        [Authorize]
        [HttpPost("UpdateUser", Name = "UpdateUser")]
        public async Task UpdateUser(UserCommandModel user) =>
            await Mediator.Send(new UpdateUserCommand(user));
    }
}
