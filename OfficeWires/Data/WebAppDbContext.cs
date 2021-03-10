using OfficeWires.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Data.Sqlite;

namespace OfficeWires.Data
{
    public class WebAppDbContext : DbContext
    {
        IConfiguration Config;
        public WebAppDbContext(IConfiguration cfg, DbContextOptions<WebAppDbContext> options) : base(options)
        {
            Config = cfg;
        }
        public DbSet<WebApp> WebApps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite(Config.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WebApp>().ToTable("WebApp");
        }
    }
}
