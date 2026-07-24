using FluentValidation;
using FluentValidation.AspNetCore;
using UserManagementWebAPI.DTO_s.Validators;
using UserManagmentWebAPI.Extensions.DataBase;
using UserManagmentWebAPI.Extensions.Middleware;
using UserManagmentWebAPI.Extensions.Repositories;
using UserManagmentWebAPI.Extensions.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration)
                .AddApplicationRepositories()
                 //For Swagger
                .AddSwaggerDocumentation()
                .AddAuthentations(builder.Configuration)
                 //For Valiation CreateUserRequest
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
                //End

var app = builder.Build();
app.ConfigureRequestPipeline();
app.Run();
