using Mercure.Common.Persistence.DataReader;
using Mercure.Common.Persistence.Transactions;
using Mercure.Common.Persistence.Translator;
using Mercure.User.Domain.Aggregate.Profile;
using Mercure.User.Domain.Aggregate.User;
using Mercure.User.Infrastructure.Logger;
using Mercure.User.Infrastructure.Persistence.Model;
using Mercure.User.Infrastructure.Persistence.Repository;
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
            services.AddSingleton<IDBContext>(new DBContext("Data Source=localhost;Initial Catalog=UserManagement;Integrated Security=True;Encrypt=False")
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

            services.AddSingleton<ILoggerProvider, LoggerProvider>();
        }
    }
}
