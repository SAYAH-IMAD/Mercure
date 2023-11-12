using Mercure.Common.Persistence.Translator;
using Mercure.User.Domain.Aggregate;
using Mercure.User.Infrastructure.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Translator
{
    internal class RoleTranslator : ITranslator<Role, RoleModel>
    {
        public RoleModel Translate(Role aggregate) 
            => new() { Id = aggregate.Identifier, Code = aggregate.Code, DateCreation = aggregate.DateCreation };

        public Role Translate(RoleModel persistence) 
            => new(persistence.Id, persistence.Code, persistence.DateCreation);
    }
}
