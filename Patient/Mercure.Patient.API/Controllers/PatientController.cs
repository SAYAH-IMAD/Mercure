using MediatR;
using Mercure.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercure.Patient.API.Controllers
{
    [ApiController]
    [Route("API/Patient/V1")]
    public class PatientController : ControllerBasic
    {
        readonly IUserProxy _proxy;

        public PatientController(IMediator mediator, IUserProxy proxy) : base(mediator)
        {
            _proxy = proxy;
        }

        [Authorize]
        [HttpGet("GetUsers", Name = "GetUsers")]
        public async Task<string> GetUsers() =>
       "await Mediator.Send(new GetUsersQuery())";
    }
}