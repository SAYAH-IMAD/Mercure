namespace Mercure.IdentityServer.Repository.UserIdentity.Model
{
    public class RoleClaim
    {
        public string Role { get; set; }

        public static implicit operator string(RoleClaim role) => role.Role;
    }
}
