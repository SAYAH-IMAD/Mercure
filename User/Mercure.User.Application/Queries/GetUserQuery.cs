using MediatR;
using Mercure.User.Application.Queries.Models;

namespace Mercure.User.Application.Queries
{
    public class GetUserQuery : IRequest<UserQueryModel>
    {
        public long Id { get; private set; }

        public GetUserQuery(long id)
        {
            Id = id;
        }
    }
}
