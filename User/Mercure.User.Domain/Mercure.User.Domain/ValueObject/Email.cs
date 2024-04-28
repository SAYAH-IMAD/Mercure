namespace Mercure.User.Domain.ValueObject
{
    public class Email : IEquatable<Email>
    {
        public Email(string value)
        {
            Value = value;
        }
        
        public string Value { get; set; }

        public static implicit operator string(Email email) => email.Value;
        public static implicit operator Email(string value) => new(value);

        public bool Equals(Email email)
        {
            return Value == email.Value;
        }
    }
}
