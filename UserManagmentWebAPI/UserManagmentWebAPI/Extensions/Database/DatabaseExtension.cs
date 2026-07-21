using Microsoft.EntityFrameworkCore;
using UserManagmentWebAPI.Data;

namespace UserManagmentWebAPI.Extensions.DataBase
{
    public static class DatabaseExtension
    {
        //---> ApplicationDbContext <---
        public static IServiceCollection AddDatabaseConnection(this IServiceCollection conn,ConfigurationManager manager )
        {
            conn.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(manager.GetConnectionString("DefaultConnection")));
            return conn;
        }
    }
}
