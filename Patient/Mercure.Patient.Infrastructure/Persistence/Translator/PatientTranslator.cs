using Mercure.Common.Persistence.Translator;
using Mercure.Patient.Domain.Aggregate;
using Mercure.Patient.Domain.ValueObject;
using Mercure.Patient.Infrastructure.Persistence.Model;

namespace Mercure.Patient.Infrastructure.Persistence.Translator
{
    public class PatientTranslator : ITranslator<PatientAggregate, PatientModel>
    {
        readonly ITranslator<Consultation, ConsultationModel> _consultationTranslator;

        public PatientTranslator(ITranslator<Consultation, ConsultationModel> consultationTranslator)
        {
            _consultationTranslator = consultationTranslator;
        }

        public PatientModel Translate(PatientAggregate aggregate) =>
            new ()
            {
                Id = aggregate.Identifier,
                FirstName = aggregate.FirstName,
                LastName = aggregate.LastName,
                Gender = aggregate.Gender,
                PhoneNumber = aggregate.PhoneNumber,
                Email = aggregate.Email,
                Street = aggregate.Address.Street,
                City = aggregate.Address.City,
                PostalCode = aggregate.Address.PostalCode,
                Consultations = aggregate.Consultations.Select(e => _consultationTranslator.Translate(e)).ToList()
            };

        public PatientAggregate Translate(PatientModel persistence) =>
                new (persistence.Id, 
                    persistence.FirstName, 
                    persistence.LastName, 
                    new Gender(persistence.Gender),
                    new Address(persistence.Street, persistence.City, persistence.PostalCode),
                    new PhoneNumber(persistence.PhoneNumber),
                    new Email(persistence.Email),
                    persistence.Consultations.Select(e => _consultationTranslator.Translate(e)).ToList());
    }
}
