namespace UserManagmentWebAPI.Extensions.FrameworkServices
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            //----> Swagger  <----
            services.AddEndpointsApiExplorer();//--> (-ASP.NET Core framework (built-in)-) this line tell the AspDotNet core collect the all API endpoints and generate the swagger document for them
            services.AddSwaggerGen();//--> ((Package)Swashbuckle.AspNetCore.SwaggerGen) this line tell the AspDotNet core to generate the swagger document for the API endpoints and also generate the swagger UI for the API endpoints
            return services;

        }
    }
}
