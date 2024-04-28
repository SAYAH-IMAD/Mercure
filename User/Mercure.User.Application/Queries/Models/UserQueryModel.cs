namespace Mercure.User.Application.Queries.Models
{
    public class UserQueryModel
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}