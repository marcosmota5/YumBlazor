using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace YumBlazor.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Category> Category { get; set; } // Name that will be used in the database
        public DbSet<Product> Product { get; set; } // Name that will be used in the database
        public DbSet<ShoppingCart> ShoppingCart { get; set; } // Name that will be used in the database
        public DbSet<OrderHeader> OrderHeader { get; set; } // Name that will be used in the database
        public DbSet<OrderDetail> OrderDetail { get; set; } // Name that will be used in the database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Don't remove because of identity
            
            modelBuilder.Entity<Category>().HasData(
                new Category {  Id = 1, Name = "Appetizer" },
                new Category { Id = 2, Name = "Entree" },
                new Category { Id = 3, Name = "Dessert" }
            );
        }
    }
}
