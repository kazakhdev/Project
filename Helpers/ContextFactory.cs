using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace project.Helpers;

public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseNpgsql("Data Source=databd.db");

        return new DataContext(optionsBuilder.Options);
    }
}