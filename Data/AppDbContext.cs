using AdvancePagination.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancePagination.Demo.Data
{
    public class AppDbContext : DbContext
    {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
      {
          
      }
        public DbSet<Post> Posts { get; set; }
    }
}