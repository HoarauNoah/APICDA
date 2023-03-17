using APICDA.Models;
using Microsoft.EntityFrameworkCore;

namespace APICDA.Data
{
    public class ShopDbContext : DbContext

    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<APICDA.Models.Product>? Product { get; set; }
        public DbSet<APICDA.Models.Supplier>? Supplier { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Token> Tokens { get; set; }
    }
}
