using Microsoft.EntityFrameworkCore;
using Timely_v1.Models;

namespace Timely_v1.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        public DbSet<Session> Sessions { get; set; }
    }
}