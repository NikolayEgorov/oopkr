using Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {}

    public DbSet<User> User { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ItemProduct> ItemProduct { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasMany(i => i.products)
            .WithMany(p => p.items).UsingEntity<ItemProduct>();

        modelBuilder.Entity<Order>().HasMany(o => o.items)
            .WithMany(i => i.orders).UsingEntity<OrderItem>();
    }
}