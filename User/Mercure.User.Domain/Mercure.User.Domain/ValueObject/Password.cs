namespace Mercure.User.Domain.ValueObject
{
    public class Password
    {
        public Password(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static implicit operator string(Password email) => email.Value;
        public static implicit operator Password(string value) => new(value);

        public bool Equals(Password email)
        {
            return Value == email.Value;
        }
    }
}
