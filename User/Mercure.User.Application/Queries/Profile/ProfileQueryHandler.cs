using MediatR;
using Mercure.Common.Persistance;
using Mercure.User.Application.Queries.Profile.Models;
using Mercure.User.Application.Queries.Profile.SQL;

namespace Mercure.User.Application.Queries.Profile
{
    public class ProfileQueryHandler : IRequestHandler<GetProfileQuery, IEnumerable<ProfileQueryModel>>
    {
        readonly IAccessDB _access;

        public ProfileQueryHandler(IAccessDB access)
        {
            _access = access;
        }

        public async Task<IEnumerable<ProfileQueryModel>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            return _access.Read<ProfileQueryModel>(ProfileSQL.GetProfile, new Dictionary<string, object>()
            {
                { "@ID", request.Id}
            });
        }
    }
}
