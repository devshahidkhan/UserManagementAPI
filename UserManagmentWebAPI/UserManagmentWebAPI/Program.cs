using UserManagmentWebAPI.Extensions.DataBase;
using UserManagmentWebAPI.Extensions.FrameworkServices;
using UserManagmentWebAPI.Extensions.Middleware;
using UserManagmentWebAPI.Extensions.Repositories;
using UserManagmentWebAPI.Extensions.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddApplicationServices()
                .AddApplicationRepositories()
                .AddDatabaseConnection(builder.Configuration)
                .AddSwaggerDocumentation();

var app = builder.Build();
app.ConfigureRequestPipeline();
app.Run();
