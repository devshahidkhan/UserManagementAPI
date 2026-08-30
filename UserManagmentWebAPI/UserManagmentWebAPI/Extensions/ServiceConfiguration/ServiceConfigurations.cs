using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;
using UserManagementWebAPI.Data;
using UserManagementWebAPI.Services.Users.Interface;
using UserManagementWebAPI.Services.Users.Implementation;
using UserManagementWebAPI.Services.Auth.Implementation;
using UserManagementWebAPI.Services.Auth.Interfaces;
using UserManagementWebAPI.Utility.Interface;
using UserManagementWebAPI.Utility.Implementation;


namespace UserManagementWebAPI.Extensions.Services
{
    public static class ServiceConfigurations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ConfigurationManager configuration) => services
            .AddScoped<IUserAuthService, UserAuthService>()
            .AddScoped<IUserService,UserService>()
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddScoped<IJwtTokenService, JwtTokenService>()
             //---> ApplicationDbContext <---
            .AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "User Management API",
                    Version = "v1"
                });

                // Define the Bearer Authentication scheme
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                // Register the operation filter to apply security requirements to endpoints
                options.OperationFilter<SecurityRequirementsOperationFilter>();

            });

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,ConfigurationManager configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            var secretKey = jwtSettings["SecretKey"];
            var validIssuer = jwtSettings["ValidIssuer"];
            var validAudience = jwtSettings["ValidAudience"];

            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!)),

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true
                    };
                });

            return services;
        }

        public static IHostBuilder AddSerilogConfiguration(this IHostBuilder host,IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            return host.UseSerilog();
        }
    }
}
