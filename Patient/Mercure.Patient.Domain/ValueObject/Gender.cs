namespace Mercure.Patient.Domain.ValueObject
{
    internal class Gender : IEquatable<Gender>
    {
        public Gender(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static implicit operator string(Gender gender) => gender.Value;
        public static implicit operator Gender(string value) => new(value);

        public bool Equals(Gender gender)
        {
            return Value == gender.Value;
        }
    }
}
