namespace Mercure.User.Infrastructure.Security
{
    internal interface IUserProvider
    {
        public User CurrentUser { get; }
    }
}
