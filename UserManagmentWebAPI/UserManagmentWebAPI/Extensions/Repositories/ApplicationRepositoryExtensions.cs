using UserManagmentWebAPI.Repositories.Implementation;
using UserManagmentWebAPI.Repositories.Interfces;

namespace UserManagmentWebAPI.Extensions.Repositories
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
