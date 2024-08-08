namespace Mercure.User.Infrastructure.Persistence.Query
{
    internal class UserQueries
    {
        public static string Insert => "INSERT INTO [USER] ([ID],[FIRST_NAME],[LAST_NAME],[EMAIL],[PASSWORD],[BIRTH_DATE],[STREET], [CITY],[POSTAL_CODE] ) VALUES (@ID,@FIRST_NAME, @LAST_NAME, @EMAIL, @PASSWORD, @BIRTH_DATE, @STREET, @CITY, @POSTAL_CODE)";
        public static string Update => "UPDATE [USER] SET [FIRST_NAME] = @FIRST_NAME, [LAST_NAME] = @LAST_NAME,[EMAIL] = @EMAIL,[PASSWORD] = @PASSWORD, [BIRTH_DATE] = @BIRTH_DATE, [STREET] = @STREET, [CITY] = @CITY, [POSTAL_CODE] = @POSTAL_CODE WHERE [ID] = @ID";
        public static string Get => "SELECT [ID], [FIRST_NAME], [LAST_NAME],[EMAIL],[PASSWORD], [BIRTH_DATE], [STREET], [CITY], [POSTAL_CODE] FROM [USER] WHERE [ID] = @ID";
        public static string Delete => "DELETE FROM [USER] WHERE [ID] = @ID";
    }
}
