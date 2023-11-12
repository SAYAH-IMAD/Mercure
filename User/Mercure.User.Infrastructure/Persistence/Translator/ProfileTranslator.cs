﻿using Mercure.Common.Persistence.Translator;
using Mercure.User.Domain.Aggregate;
using Mercure.User.Infrastructure.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence.Translator
{
    public class ProfileTranslator : ITranslator<ProfileAggregate, ProfileModel>
    {
        readonly ITranslator<Role, RoleModel> _roleTranslator;

        public ProfileTranslator(ITranslator<Role, RoleModel> roleTranslator)
        {
            _roleTranslator = roleTranslator;
        }
        public ProfileModel Translate(ProfileAggregate aggregate)
            => new() { Id = aggregate.Identifier, Title = aggregate.Title, HistoryRole = aggregate.HistoryRole.Select(e => _roleTranslator.Translate(e)).ToList() };

        public ProfileAggregate Translate(ProfileModel persistence)
            => new(persistence.Id, persistence.Title, persistence.HistoryRole.Select(e => _roleTranslator.Translate(e)).ToList());
    }
}
