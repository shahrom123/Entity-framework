using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().HasData
        (
            new List<Order>()
            {
                new Order(1,DateTimeOffset.UtcNow, DateTimeOffset.UtcNow, 1),
                new Order(2,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow ,2),
                new Order(3,DateTimeOffset.UtcNow,DateTimeOffset.UtcNow ,3),
            });

        modelBuilder.Entity<Product>().HasData(
          new List<Product>(){
                 new Product(1, "a ", 1210),
                
                 new Product(2, "b ", 10),

                 new Product(3, "c ", 12),

          });
        
        modelBuilder.Entity<Customer>().HasData
            (new List<Customer>()
            {
                new Customer (1, "Shahrom", " Sh ", " Dushanbe ", "909050400 ", " Sh@gmail.com"),
                new Customer (2, "Shahrom", " Shar ", " TJK ", "909050430 ", " Shahr@gmail.com"),
                new Customer (3, "Shahrom", " Sharipov ", " Vakhsh ", "909050409 ", " Shahrom@gmail.com"),

            });


        base.OnModelCreating(modelBuilder);
    }
}

