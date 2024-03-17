namespace Mercure.User.Application.Queries.SQL
{
    internal class UserSQL
    {
        public const string GetUsers = "SELECT U.[ID],U.[FIRST_NAME],U.[LAST_NAME],U.[EMAIL],U.[PASSWORD],U.[BIRTH_DATE],U.[STREET],U.[CITY],U.[POSTAL_CODE] FROM [USER] U";

        public const string GetUserById = "SELECT U.[ID],U.[FIRST_NAME],U.[LAST_NAME],U.[EMAIL],U.[PASSWORD],U.[BIRTH_DATE],U.[STREET],U.[CITY],U.[POSTAL_CODE] FROM [USER] U  WHERE U.[ID] = @ID";

        public const string GetUserByEmail = "SELECT U.[ID],U.[FIRST_NAME],U.[LAST_NAME],U.[EMAIL],U.[PASSWORD],U.[BIRTH_DATE],U.[STREET],U.[CITY],U.[POSTAL_CODE] FROM [USER] U  WHERE U.[EMAIL] = @EMAIL AND U.[PASSWORD] = @PASSWORD";
    }
}
