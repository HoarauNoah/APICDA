using APICDA.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace APICDA.Data
{
    public class ShopDbContext : DbContext

    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>()
                .Property(b => b.id)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(b => b.id)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(b => b.id)
                .IsRequired();
            modelBuilder.Entity<Category>()
                .Property(b => b.id)
                .IsRequired();
        }
        
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Token> Tokens { get; set; }
    }
}
