using Mercure.Common.Exceptions;

namespace Mercure.User.Domain.Exceptions
{
    internal class RemoveProfileException : FunctionalException
    {
        public RemoveProfileException() 
            : base("user does not have this profile")
        {
        }
    }
}
