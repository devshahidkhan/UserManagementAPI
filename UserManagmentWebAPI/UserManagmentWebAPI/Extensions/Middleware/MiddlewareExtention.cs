namespace UserManagmentWebAPI.Extensions.Middleware
{
    public static class MiddlewareExtention
    {
        public static WebApplication ConfigureRequestPipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); //-->((Package)Swashbuckle.AspNetCore.Swagger) This is a middleware and work of this middleware to generate the URL and also give the Json code
                app.UseSwaggerUI(); //-->((Package)Swashbuckle.AspNetCore.SwaggerUI) This is also middleware and Convert the Json into beautiful webpage
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            return app;
        }
    }
}
