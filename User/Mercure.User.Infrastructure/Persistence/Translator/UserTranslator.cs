using Mercure.Common.Persistence;
using Mercure.User.Domain.Aggregate.Profile;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Domain.ValueObject;
using Mercure.User.Infrastructure.Persistence.Model;

namespace Mercure.User.Infrastructure.Persistence
{
    public class UserTranslator : ITranslator<UserAggregate, UserModel>
    {
        readonly ITranslator<ProfileAggregate, ProfileModel> _profileTranslator;
        readonly ITranslator<UserProfile, UserProfileModel> _userProfileTranslator;
        readonly ITranslator<UserState, UserStateModel> _userStateTranslator;

        public UserTranslator(ITranslator<ProfileAggregate, ProfileModel> profileTranslator,
            ITranslator<UserProfile, UserProfileModel> userProfileTranslator,
            ITranslator<UserState, UserStateModel> userStateTranslator)
        {
            _profileTranslator = profileTranslator;
            _userProfileTranslator = userProfileTranslator;
            _userStateTranslator = userStateTranslator;
        }

        public UserModel Translate(UserAggregate aggregate)
            => new() { Id = aggregate.Identifier, 
                FirstName = aggregate.FirstName, 
                LastName = aggregate.LastName, 
                Street = aggregate.Address.Street,
                City = aggregate.Address.City, 
                PostalCode = aggregate.Address.PostalCode, 
                BirthDate = aggregate.BirthDate, 
                HistoryStates = aggregate.HistoryStates.Select(e => _userStateTranslator.Translate(e)).ToList(), 
                Profiles = aggregate.Profiles.Select(e => _userProfileTranslator.Translate(e)).ToList() };

        public UserAggregate Translate(UserModel persistence)
            => new(persistence.Id, 
                persistence.FirstName, 
                persistence.LastName, 
                new Address(persistence.Street, persistence.City, persistence.PostalCode), 
                persistence.BirthDate, 
                persistence.HistoryStates.Select(e => _userStateTranslator.Translate(e)).ToList(), 
                persistence.Profiles.Select(e => _userProfileTranslator.Translate(e)).ToList());
    }
}
