using MediatR;
using Mercure.Common;
using Mercure.User.Application.Commands;
using Mercure.User.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mercure.User.API.Controllers
{
    [ApiController]
    [Route("API/User/V1")]
    public class UserController : ControllerBasic
    {
        public UserController(IMediator mediator)
            :base(mediator)
        {
        }

        [HttpGet("GetUser")]
        public async Task<UserQueryModel> GetUser(int id) =>
            await Mediator.Send(new GetUserQuery(id));

        [HttpPost("CreateUser")]
        public async Task CreateUser(UserCommandModel user) =>
            await Mediator.Send(new CreateUserCommand(user));

    }
}
