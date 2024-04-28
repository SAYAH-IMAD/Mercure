namespace Mercure.User.Application.Queries.Models
{
    public class RegisterUserQueryModel
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string ExpireIn { get; set; }
        public string Token { get; set; }
    }
}
