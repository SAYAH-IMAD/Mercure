using Mercure.Common;
using Mercure.Common.Persistence;
using Mercure.User.Domain.Aggregate.Profile;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Infrastructure.Persistence;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Transaction;
using Mercure.User.Infrastructure.Persistence.Translator;
using Microsoft.Extensions.DependencyInjection;

namespace Mercure.User.Infrastructure
{
    public static class Injection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IAccessDB>(new AccessDB("Data Source=localhost;Initial Catalog=UserManagement;Integrated Security=True;Encrypt=False")
                .ConfigureMapping());
          
            services.AddSingleton<ITransaction<ProfileModel>, ProfileTransaction>();
            services.AddSingleton<ITransaction<UserModel>, UserTransaction>();
            services.AddSingleton<ITransaction<UserStateModel>, UserStateTransaction>();
            services.AddSingleton<ITransaction<UserProfileModel>, UserProfileTransaction>();
            services.AddSingleton<ITransaction<RoleModel>, RoleTransaction>();

            services.AddSingleton<ITranslator<UserAggregate, UserModel>, UserTranslator>();
            services.AddSingleton<ITranslator<UserState, UserStateModel>, UserStateTranslator>();
            services.AddSingleton<ITranslator<UserProfile, UserProfileModel>, UserProfileTranslator>();
            services.AddSingleton<ITranslator<ProfileAggregate, ProfileModel>, ProfileTranslator>();
            services.AddSingleton<ITranslator<Role, RoleModel>, RoleTranslator>();
        }
    }
}
