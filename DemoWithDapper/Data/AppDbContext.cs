using Microsoft.EntityFrameworkCore;
using DemoWithDapper.Models;

namespace DemoWithDapper.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Comapanies { get; set; }
    }
}
