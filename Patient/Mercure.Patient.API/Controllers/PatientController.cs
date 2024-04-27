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

        public PatientController(IMediator mediator, IUserProxy proxy) : base(mediator)
        {
            _proxy = proxy;
        }

        [HttpGet("GetPatient", Name = "GetPatient")]
        public string Test() 
        {
            return "hello";
        }
    }
}