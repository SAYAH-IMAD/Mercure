using MediatR;
using Mercure.User.Application.Queries.Models;

namespace Mercure.User.Application.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserQueryModel>>
    {
    }
}
