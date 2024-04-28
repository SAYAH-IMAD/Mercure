using Mercure.Common.Interface;
using Mercure.User.Domain.Aggregate.User;

namespace Mercure.User.Domain.Test.Builder
{
    internal class UserProfileBuilder : IBuilder<UserProfile>
    {
        long _profileId;
        DateTime _dateCreation;

        public UserProfileBuilder WithProfileId(long profileId)
        {
            _profileId = profileId;
            
            return this;
        }

        public UserProfileBuilder WithDateCreation(DateTime dateCreation)
        {
            _dateCreation = dateCreation;

            return this;
        }

        public UserProfile Build() 
        { 
            return UserProfile.Create(_profileId, _dateCreation);
        }
    }
}
