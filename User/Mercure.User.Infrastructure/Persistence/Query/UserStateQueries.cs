namespace Mercure.User.Infrastructure.Persistence
{
    internal class UserStateQueries
    {
        public static string Insert => "INSERT INTO [USER_STATE] ([ID], [USER_ID], [CREATION_DATE]) VALUES (@ID, @USER_ID, @CREATION_DATE)";
        public static string GetById => "SELECT [ID], [USER_ID],[CREATION_DATE] FROM [USER_STATE] WHERE [ID] = @ID";
        public static string GetByParentKey => "SELECT [ID], [USER_ID],[CREATION_DATE] FROM [USER_STATE] WHERE [USER_ID] = @USER_ID";
        public static string Delete => "DELETE FROM [USER_STATE] WHERE [ID] = @ID";
    }
}
