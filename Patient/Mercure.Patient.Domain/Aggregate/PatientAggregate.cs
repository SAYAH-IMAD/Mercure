using Mercure.Common.Domain;
using Mercure.Patient.Domain.ValueObject;

namespace Mercure.Patient.Domain.Aggregate
{
    public class PatientAggregate : AggregateRoot
    {
        public PatientAggregate(long? id,
            string lastName,
            string firstName,
            Gender gender,
            Address address,
            PhoneNumber phoneNumber,
            Email email,
            List<Consultation> consultations) : base(id)
        {
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Consultations = consultations;
        }

        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public Gender Gender { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Email Email { get; private set; }
        public ICollection<Consultation> Consultations { get; set; }

        public static PatientAggregate Create(string lastName,
            string firstName,
            Gender gender,
            Address address,
            PhoneNumber phoneNumber,
            Email email) => new(null, lastName, firstName, gender, address, phoneNumber, email, new List<Consultation>());

        public void Update(string lastName,
            string firstName,
            Gender gender,
            Address address,
            PhoneNumber phoneNumber,
            Email email)
        {
            LastName = lastName;
            FirstName = firstName;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void AddConsultation(Consultation consultation) 
        {
            if (consultation is not null)
                Consultations.Add(consultation);
        }


    }
}
