using Microsoft.EntityFrameworkCore;
using UserManagementWebAPI.Data.Entities;

namespace UserManagementWebAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
