using UserManagmentWebAPI.Services.Implementation;
using UserManagmentWebAPI.Services.Interfaces;

namespace UserManagmentWebAPI.Extensions.Services
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //---> Services <---
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            return services;
        }
    }
}
