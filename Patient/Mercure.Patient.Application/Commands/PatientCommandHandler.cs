using MediatR;
using Mercure.Patient.Domain.Aggregate;
using Mercure.Patient.Domain.ValueObject;

namespace Mercure.Patient.Application.Commands
{
    internal class PatientCommandHandler : IRequestHandler<CreatePatientCommand>
    {
        public async Task Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            PatientAggregate patient = PatientAggregate.Create(request.Patient.LastName,
                request.Patient.FirstName,
                new Gender(request.Patient.Gender),
                new Address(request.Patient.Street, request.Patient.City, request.Patient.PostalCode),
                new PhoneNumber(request.Patient.PhoneNumber),
                new Email(request.Patient.Email));

        }
    }
}
