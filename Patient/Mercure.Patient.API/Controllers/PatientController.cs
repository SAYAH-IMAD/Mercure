using MediatR;
using Mercure.Common;
using Microsoft.AspNetCore.Mvc;

namespace Mercure.Patient.API.Controllers
{
    [ApiController]
    [Route("API/Patient/V1")]
    public class PatientController : ControllerBasic
    {
        readonly IUserProxy _proxy;

        //public PatientController(IMediator mediator) : base(mediator)
        //{
        //    _proxy = new UserProxy("https://localhost:7021/", new HttpClient());
        //}

        [HttpGet("GetUsers")]
        public async Task<IEnumerable<UserQueryModel>> GetUsers() =>           
            await _proxy.GetUsersAsync();

        public PatientController(IMediator mediator, IUserProxy proxy) : base(mediator)
        {
            _proxy = proxy;
        }
    }
}