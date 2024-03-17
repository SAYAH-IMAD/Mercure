using Mercure.Common.Domain;
using Mercure.Patient.Domain.ValueObject;

namespace Mercure.Patient.Domain.Aggregate
{
    internal class PatientAggregate : AggregateRoot
    {
        private PatientAggregate(long? id,
            string lastName,
            string firstName,
            Address address,
            PhoneNumber phoneNumber,
            PhoneNumber emergencyPhoneNumber) : base(id)
        {
            LastName = lastName;
            FirstName = firstName;
            Address = address;
            PhoneNumber = phoneNumber;
            EmergencyPhoneNumber = emergencyPhoneNumber;
        }

        /// Personal Information
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public PhoneNumber EmergencyPhoneNumber { get; private set; }

        /// Medical Information

        public static PatientAggregate Create(string lastName,
            string firstName,
            Address address,
            PhoneNumber phoneNumber,
            PhoneNumber emergencyPhoneNumber) => new(null, lastName, firstName, address, phoneNumber, emergencyPhoneNumber);
    }
}
