using MediatR;
using Mercure.Patient.Domain.Aggregate;
using Mercure.Patient.Domain.ValueObject;
using Mercure.Patient.Infrastructure.Persistence.Repository;

namespace Mercure.Patient.Application.Commands
{
    internal class PatientCommandHandler : IRequestHandler<CreatePatientCommand>,
                                           IRequestHandler<UpdatePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public PatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;    
        }

        public async Task Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            PatientAggregate patient = PatientAggregate.Create(request.Patient.LastName,
                request.Patient.FirstName,
                new Gender(request.Patient.Gender),
                new Address(request.Patient.Street, request.Patient.City, request.Patient.PostalCode),
                new PhoneNumber(request.Patient.PhoneNumber),
                new Email(request.Patient.Email));
        }

        public async Task Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            PatientAggregate patient = _patientRepository.GetById(request.Patient.Id);

            patient.Update(request.Patient.LastName, 
                request.Patient.FirstName,
                new Gender(request.Patient.Gender), 
                new Address(request.Patient.Street, request.Patient.City, request.Patient.PostalCode),
                new PhoneNumber(request.Patient.PhoneNumber),
                new Email(request.Patient.Email));

            _patientRepository.Save(ref patient);
        }
    }
}
