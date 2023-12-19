using Microsoft.EntityFrameworkCore;
using OiBoba.Models;

namespace OiBoba.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public virtual DbSet<Product> Products { get; set; }
    }
}
