using MediatR;
using Mercure.User.Application.Queries.Profile.Models;

namespace Mercure.User.Application.Queries.Profile
{
    public class GetProfileQuery : IRequest<IEnumerable<ProfileQueryModel>>
    {
        public long Id { get; private set; }

        public GetProfileQuery(long id)
        {
            Id = id;
        }
    }
}
