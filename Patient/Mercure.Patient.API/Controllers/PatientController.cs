
using MediatR;
using Mercure.Common;
using Mercure.Patient.Application.Commands;
using Mercure.Patient.Application.Commands.Model;
using Microsoft.AspNetCore.Mvc;

namespace Mercure.Patient.API.Controllers
{
    [ApiController]
    [Route("API/Patient/V1")]
    public class PatientController : ControllerBasic
    {

        public PatientController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("CreatePatient", Name = "CreatePatient")]
        public async Task CreatePatient(PatientCommandModel patient) =>
            await Mediator.Send(new CreatePatientCommand(patient));

        [HttpGet("UpdatePatient", Name = "UpdatePatient")]
        public async Task UpdatePatient(PatientCommandModel patient) =>
             await Mediator.Send(new UpdatePatientCommand(patient));

        [HttpGet("Consult", Name = "Consult")]
        public async Task Consult(PatientCommandModel patient) =>
             await Mediator.Send(new UpdatePatientCommand(patient));
    }
}