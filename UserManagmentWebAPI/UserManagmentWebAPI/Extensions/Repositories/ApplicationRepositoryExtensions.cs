using UserManagementWebAPI.Repositories.Implementation;
using UserManagementWebAPI.Repositories.Interfces;
using UserManagementWebAPI.Repositories.Users.Implementation;
using UserManagementWebAPI.Repositories.Users.Interface;

namespace UserManagementWebAPI.Extensions.Repositories
{
    public static class ApplicationRepositoryExtensions
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            //---> Repositories <---
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
