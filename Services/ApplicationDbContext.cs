using Microsoft.EntityFrameworkCore;
using SPO.Models;

namespace SPO.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> orders { get; set; }
    }

}
