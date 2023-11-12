using MediatR;
using Mercure.User.Application.Queries.Models;
using Mercure.User.Domain.Aggregate;
using Mercure.User.Domain.Exceptions;
using Mercure.User.Infrastructure.Persistence.Repository;

namespace Mercure.User.Application.Queries
{
    public class UserQueryHandler : IRequestHandler<GetUserQuery, UserQueryModel>
    {
        readonly IUserRepository _userRepository;

        public UserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserQueryModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            UserAggregate aggregate = _userRepository.GetById(request.Id);

            if (aggregate == null)
                throw new AggregatNullException(nameof(UserAggregate), request.Id);

            return new()
            {
                Id = aggregate.Identifier.Value,
                LastName = aggregate.LastName,
                FirstName = aggregate.FirstName,
                Address = aggregate.Address,
                BirthDate = aggregate.BirthDate,
            };
        }
    }
}
