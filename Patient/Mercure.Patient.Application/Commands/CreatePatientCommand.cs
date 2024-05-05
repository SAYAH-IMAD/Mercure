using MediatR;
using Mercure.Patient.Application.Commands.Model;

namespace Mercure.Patient.Application.Commands
{
    public class CreatePatientCommand : IRequest
    {
        public PatientCommandModel Patient { get; set; }

        public CreatePatientCommand(PatientCommandModel patient)
        {
            Patient = patient;
        }
    }
}
