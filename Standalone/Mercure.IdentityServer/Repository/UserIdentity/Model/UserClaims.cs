namespace Mercure.IdentityServer.Repository.UserIdentity.Model
{
    public class UserClaims
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
