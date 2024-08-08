using MediatR;
using Mercure.Patient.Application.Commands.Model;

namespace Mercure.Patient.Application.Commands
{
    public class UpdatePatientCommand : IRequest
    {
        public PatientCommandModel Patient { get; set; }

        public UpdatePatientCommand(PatientCommandModel patient)
        {
            Patient = patient;
        }
    }
}
