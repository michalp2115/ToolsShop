using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using Tools.Models;

namespace Tools.DataAccess;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CoverType> CoverTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<Product>(b =>
        {
            b.HasData(new Product()
            {
                Id = 10,
                Name = "Hammer",
                Description = "desc",
                CompanyName = "Company",
                ListPrice = 32,
                Price = 40,
                CatalogNumber = "123",
                Price50 = 30,
                Price100 = 20,
                ImageUrl = "https://cdn-reichelt.de/bilder/web/xxl_ws/D300/FAEUSTEL.png"
            });
            b.OwnsOne(e => e.Category).HasData(new Category()
            {
                Id = 10,
                Name = "Category",
                DisplayOrder = 1,
            });
            b.OwnsOne(c => c.CoverType).HasData(new CoverType()

            {
                Id = 10,
                Name = "IsLimited"
            });                   
        });
    }
}

