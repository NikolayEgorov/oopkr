using Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {}

    public DbSet<Log> Log { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Boller> Boller { get; set; }
    public DbSet<Plant> Plant { get; set; }
    public DbSet<Hour> Hour { get; set; }
    public DbSet<Day> Day { get; set; }
    public DbSet<Month> Month { get; set; }
    public DbSet<PlantBoller> PlantBoller { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>().HasMany(p => p.bollers)
            .WithMany(b => b.plants).UsingEntity<PlantBoller>();

        // modelBuilder.Entity<Item>().HasMany(i => i.products)
        //     .WithMany(p => p.items).UsingEntity<ItemProduct>();

        // modelBuilder.Entity<Order>().HasMany(o => o.items)
        //     .WithMany(i => i.orders).UsingEntity<OrderItem>();
    }
}