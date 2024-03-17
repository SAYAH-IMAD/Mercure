namespace Mercure.User.Application.Queries.Profile.SQL
{
    internal class ProfileSQL
    {
        public const string GetProfile = "SELECT UP.ID as Id, P.Title as Name FROM [UserManagement].[dbo].[USER_PROFILE] UP JOIN [UserManagement].[dbo].[PROFILE] P ON UP.PROFILE_ID = P.Id WHERE UP.USER_ID = @ID";
    }
}
