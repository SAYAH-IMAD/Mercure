namespace Mercure.User.Infrastructure.Security
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public IReadOnlyCollection<string> Permissions { get; set; }
        public IReadOnlyCollection<string> Roles { get; set; }
    }
}
