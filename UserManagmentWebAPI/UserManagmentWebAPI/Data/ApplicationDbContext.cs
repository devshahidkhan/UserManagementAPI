using Microsoft.EntityFrameworkCore;
using UserManagmentWebAPI.Entities;

namespace UserManagmentWebAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
