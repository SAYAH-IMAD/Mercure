namespace Mercure.User.Infrastructure.Persistence
{
    internal static class ProfileQueries
    {
        public static string Insert => "INSERT INTO [Profile] ([Id], [Title], [UserId]) VALUES (@Id, @Title, @UserId)";
        public static string Update => "UPDATE [Profile] SET [Title] = @Title WHERE [Id] = @Id";
        public static string GetById => "SELECT [Id], [Title] FROM [Profile] WHERE [Id] = @Id";
        public static string GetByParentKey => "SELECT [Id], [Title] FROM [Profile] WHERE [UserId] = @UserId";
        public static string Delete => "DELETE FROM [Profile] WHERE [Id] = @Id";
    }
}
