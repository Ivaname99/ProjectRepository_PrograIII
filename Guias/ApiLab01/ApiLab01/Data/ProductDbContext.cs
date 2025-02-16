using ApiLab01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ApiLab01.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        
        public DbSet<Productos> Productos { get; set; }
    }
}
 