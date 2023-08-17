namespace project.Helpers;

using Microsoft.EntityFrameworkCore;
using project.Entities;
using System.Reflection.Emit;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }

    private readonly IConfiguration Configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=kazakh;Host=localhost;Port=5432;Database=databd;Pooling=true;");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Todo>()
        .Property(b => b.Id)
        .IsRequired();

    }
}