using Mercure.Common.Exceptions;

namespace Mercure.User.Domain.Exceptions
{
    internal class AssignProfileException : FunctionalException
    {
        public AssignProfileException() 
            : base("user already has a similar profile")
        {
        }
    }
}
