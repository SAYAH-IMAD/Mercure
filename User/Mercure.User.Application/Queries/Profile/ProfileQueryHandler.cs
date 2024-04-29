using MediatR;
using Mercure.Common.Persistence.DataReader;
using Mercure.User.Application.Queries.Profile.Models;
using Mercure.User.Application.Queries.Profile.SQL;

namespace Mercure.User.Application.Queries.Profile
{
    public class ProfileQueryHandler : IRequestHandler<GetProfileQuery, IEnumerable<ProfileQueryModel>>
    {
        readonly IDBContext _context;

        public ProfileQueryHandler(IDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfileQueryModel>> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            return _context.Read<ProfileQueryModel>(ProfileSQL.GetProfile, new Dictionary<string, object>()
            {
                { "@ID", request.Id}
            });
        }
    }
}
