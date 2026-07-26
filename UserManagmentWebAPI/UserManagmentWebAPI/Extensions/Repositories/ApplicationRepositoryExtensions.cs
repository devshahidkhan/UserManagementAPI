using UserManagementWebAPI.Repositories.Implementation;
using UserManagementWebAPI.Repositories.Interfces;

namespace UserManagementWebAPI.Extensions.Repositories
{
    public static class ApplicationRepositoryExtensions
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            //---> Repositories <---
            services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();
            return services;
        }
    }
}
