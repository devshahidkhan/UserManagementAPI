using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using UserManagmentWebAPI.Data;
using UserManagmentWebAPI.Repositories.Implementation;
using UserManagmentWebAPI.Repositories.Interfces;
using UserManagmentWebAPI.Services.Implementation;
using UserManagmentWebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//----> Swagger  <----
builder.Services.AddEndpointsApiExplorer();//--> (-ASP.NET Core framework (built-in)-) this line tell the AspDotNet core collect the all API endpoints and generate the swagger document for them
builder.Services.AddSwaggerGen();//--> ((Package)Swashbuckle.AspNetCore.SwaggerGen) this line tell the AspDotNet core to generate the swagger document for the API endpoints and also generate the swagger UI for the API endpoints

//---> ApplicationDbContext <---
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//---> Services <---
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

//---> Repositories <---
builder.Services.AddScoped<IUserAuthenticationRepository,UserAuthenticationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //-->((Package)Swashbuckle.AspNetCore.Swagger) This is a middleware and work of this middleware to generate the URL and also give the Json code
    app.UseSwaggerUI(); //-->((Package)Swashbuckle.AspNetCore.SwaggerUI) This is also middleware and Convert the Json into beautiful webpage
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
