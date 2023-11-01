
namespace Mercure.User.Domain.ValueObject
{
    public class Address : IEquatable<Address>
    {
        public Address(string street,
            string city,
            string postalCode)
        {
            if (string.IsNullOrEmpty(street))
                throw new ArgumentNullException(nameof(street));
            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException(nameof(city));
            if (string.IsNullOrEmpty(postalCode))
                throw new ArgumentNullException(nameof(postalCode));

            Street = street;
            City = city;
            PostalCode = postalCode;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }

        public static implicit operator string(Address address) => $"{address.Street}, {address.City}, {address.PostalCode}";
        public static implicit operator Address(string[] address) => new(address[0], address[1], address[2]);

        public bool Equals(Address other) => other.Street == Street
                && other.City == City
                && other.PostalCode == PostalCode;
    }
}
