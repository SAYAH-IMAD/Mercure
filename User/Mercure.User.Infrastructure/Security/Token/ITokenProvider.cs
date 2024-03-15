namespace Mercure.User.Infrastructure.Security.Token
{
    public interface ITokenProvider
    {
        string GenerateToken(int id, string email, List<string> roles, List<string> permissions);
    }
}
