using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OiBoba.Models;

namespace OiBoba.DataAccessLayer
{
    public class AppDbContext : IdentityDbContext
    {
        public virtual DbSet<Product> Product { get; set; }
        public DbSet<Categoria> Categoria { get; set; } = default!;
        public DbSet<Marca> Marca { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var stringConn = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(stringConn);
        }
    }
}
