using Mercure.Common.Exceptions;

namespace Mercure.User.Domain.Exceptions
{
    public class AggregatNullException : FunctionalException
    {
        public AggregatNullException(string aggregat, long id) 
            : base($"There is no aggregate for {aggregat} with id {id}")
        {
        }
    }
}
