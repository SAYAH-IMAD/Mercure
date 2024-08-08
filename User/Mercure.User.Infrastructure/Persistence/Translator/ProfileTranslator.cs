using Mercure.Common.Persistence.Translator;
using Mercure.User.Domain.Aggregate.Profile;
using Mercure.User.Infrastructure.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Translator
{
    internal class ProfileTranslator : ITranslator<ProfileAggregate, ProfileModel>
    {
        readonly ITranslator<Role, RoleModel> _roleTranslator;

        public ProfileTranslator(ITranslator<Role, RoleModel> roleTranslator)
        {
            _roleTranslator = roleTranslator;
        }
        public ProfileModel Translate(ProfileAggregate aggregate)
            => new() { Id = aggregate.Identifier, Title = aggregate.Title, Roles = aggregate.Roles.Select(e => _roleTranslator.Translate(e)).ToList() };

        public ProfileAggregate Translate(ProfileModel persistence)
            => new(persistence.Id, persistence.Title, persistence.Roles.Select(e => _roleTranslator.Translate(e)).ToList());
    }
}
