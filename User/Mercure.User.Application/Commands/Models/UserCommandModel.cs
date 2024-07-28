namespace Mercure.User.Application.Commands
{
    public class UserCommandModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
