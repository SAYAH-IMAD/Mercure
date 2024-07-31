using MediatR;
using Mercure.Common;
using Mercure.User.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Mercure.User.API.Controllers
{
    [ApiController]
    [Route("API/User/V1")]
    public class ProfileController : ControllerBasic
    {
        public ProfileController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpPost("CreateProfile", Name = "CreateProfile")]
        public async Task CreateProfile(ProfileCommandModel profile) 
            => Mediator.Send(new CreateProfileCommand(profile));
    }
}
