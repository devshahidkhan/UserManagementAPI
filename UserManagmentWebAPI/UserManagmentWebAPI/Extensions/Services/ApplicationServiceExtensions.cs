using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;
using UserManagementWebAPI.Services.Implementation;
using UserManagementWebAPI.Services.Interfaces;
using UserManagementWebAPI.Data;


namespace UserManagementWebAPI.Extensions.Services
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,ConfigurationManager manager) => services
            .AddScoped<IUserAuthenticationService, UserAuthenticationService>()
            .AddScoped<IPasswordHasher, PasswordHasher>()
            .AddScoped<IJwtTokenService, JwtTokenService>()
             //---> ApplicationDbContext <---
            .AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(manager.GetConnectionString("DefaultConnection")));



        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
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

                var assembly = Assembly.GetExecutingAssembly();
                var xmlFile = $"{assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IServiceCollection AddAuthentations(this IServiceCollection Services, ConfigurationManager configurationManager)
        {
            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidAudience = "abcxyzxyedh",
                        ValidIssuer = "www.hkxljsxiuwhuxhusxnoz.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager.GetSection("APITokenKey")["Key"]!)),
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true
                    };
                });

            return Services;
        }

        public static IHostBuilder AddSerilogConfiguration(this IHostBuilder host,IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            return host.UseSerilog();
        }

        //{
        //    //---> Services <---
        //    services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
        //    services.AddScoped<IPasswordHasher, PasswordHasher>();
        //    services.AddScoped<IJwtTokenService, JwtTokenService>();
        //    return services;
        //}
    }
}
