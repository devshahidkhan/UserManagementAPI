using Serilog;
using UserManagementWebAPI.Middlewares;

namespace UserManagementWebAPI.Extensions.Middleware
{
    public static class MiddlewareConfigurations
    {
        public static WebApplication ConfigureRequestPipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); //-->((Package)Swashbuckle.AspNetCore.Swagger) This is a middleware and work of this middleware to generate the URL and also give the Json code
                app.UseSwaggerUI(); //-->((Package)Swashbuckle.AspNetCore.SwaggerUI) This is also middleware and Convert the Json into beautiful webpage
            }

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseAuthentication();
            app.UseAuthorization();
     
            app.MapControllers();

            return app;
        }
    }
}
