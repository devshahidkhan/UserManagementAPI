using FluentValidation;
using FluentValidation.AspNetCore;
using UserManagementWebAPI.DTO_s.Validators;
using UserManagementWebAPI.Filters;
using UserManagementWebAPI.Extensions.Middleware;
using UserManagementWebAPI.Extensions.Repositories;
using UserManagementWebAPI.Extensions.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(option =>
{
    option.Filters.Add<ValidateModelState>(); //use for model Validation(override)
});

builder.Services.AddApplicationServices(builder.Configuration)
                .AddApplicationRepositories()
                 //For Swagger(Extension)
                .AddCustomSwagger()
                .AddJwtAuthentication(builder.Configuration)
                //For Valiation CreateUserRequest(Extension)
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
//End
builder.Host.AddSerilogConfiguration(builder.Configuration);

var app = builder.Build();
app.ConfigureRequestPipeline();
app.Run();
