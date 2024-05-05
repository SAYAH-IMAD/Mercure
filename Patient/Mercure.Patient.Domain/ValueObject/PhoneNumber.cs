namespace Mercure.Patient.Domain.ValueObject
{
    public class PhoneNumber : IEquatable<PhoneNumber>
    {
        public PhoneNumber(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }

        public static implicit operator string(PhoneNumber number) => number.Value;
        public static implicit operator PhoneNumber(string value) => new(value);

        public bool Equals(PhoneNumber other) => other.Value == Value;
    }
}
