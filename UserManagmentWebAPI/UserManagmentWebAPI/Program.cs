using FluentValidation;
using FluentValidation.AspNetCore;
using UserManagementWebAPI.DTO_s.Validators;
using UserManagementWebAPI.Filters;
using UserManagmentWebAPI.Extensions.Middleware;
using UserManagmentWebAPI.Extensions.Repositories;
using UserManagmentWebAPI.Extensions.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(option =>
{
    option.Filters.Add<ValidateModelState>(); //use for model Validation(override)
});
builder.Services.AddApplicationServices(builder.Configuration)
                .AddApplicationRepositories()
                 //For Swagger(Extension)
                .AddSwaggerDocumentation()
                .AddAuthentations(builder.Configuration)
                //For Valiation CreateUserRequest(Extension)
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
//End
builder.Host.AddSerilogConfiguration(builder.Configuration);

var app = builder.Build();
app.ConfigureRequestPipeline();
app.Run();
