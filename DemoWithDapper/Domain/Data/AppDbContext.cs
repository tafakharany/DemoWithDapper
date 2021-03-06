using Microsoft.EntityFrameworkCore;
using DemoWithDapper.Domain.Models;

namespace DemoWithDapper.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
    }
}
