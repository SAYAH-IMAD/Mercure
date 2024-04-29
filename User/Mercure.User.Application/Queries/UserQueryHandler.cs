using MediatR;
using Mercure.Common.Persistence.DataReader;
using Mercure.User.Application.Queries.Models;
using Mercure.User.Application.Queries.SQL;

namespace Mercure.User.Application.Queries
{
    public class UserQueryHandler : IRequestHandler<GetUserQuery, UserQueryModel>,
                                    IRequestHandler<RegisterUserQuery, RegisterUserQueryModel>,
                                    IRequestHandler<GetUsersQuery, IEnumerable<UserQueryModel>>
    {
        readonly IDBContext _context;

        public UserQueryHandler(IDBContext context)
        {
            _context = context;
        }

        public async Task<UserQueryModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return _context.ReadFirst<UserQueryModel>(UserSQL.GetUserById, new Dictionary<string, object>()
            {
                { "@ID", request.Id}
            });
        }

        public async Task<IEnumerable<UserQueryModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return _context.Read<UserQueryModel>(UserSQL.GetUsers, new Dictionary<string, object>() { });
        }

        public async Task<RegisterUserQueryModel> Handle(RegisterUserQuery request, CancellationToken cancellationToken)
        {
            return _context.ReadFirst<RegisterUserQueryModel>(UserSQL.GetUserByEmail, new Dictionary<string, object>()
            {
                { "@EMAIL", request.Email},
                { "@PASSWORD", request.Password}
            });
        }
    }
}
