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
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Token> Tokens { get; set; }
    }
}
