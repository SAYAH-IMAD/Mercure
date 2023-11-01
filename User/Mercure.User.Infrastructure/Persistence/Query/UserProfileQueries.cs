namespace Mercure.User.Infrastructure.Persistence.Query
{
    internal class UserProfileQueries
    {
        public static string Insert => "INSERT INTO [USER_PROFILE] ([ID], [PROFILE_ID], [USER_ID], [CREATION_DATE]) VALUES (@ID, @PROFILE_ID, @USER_ID, @CREATION_DATE)";
        public static string GetById => "SELECT [ID], [PROFILE_ID], [USER_ID],[CREATION_DATE] FROM [USER_PROFILE] WHERE [ID] = @ID";
        public static string GetByParentKey => "SELECT [ID], [PROFILE_ID], [USER_ID],[CREATION_DATE] FROM [USER_PROFILE] WHERE [USER_ID] = @USER_ID";
        public static string Delete => "DELETE FROM [USER_PROFILE] WHERE [ID] = @ID";
    }
}
