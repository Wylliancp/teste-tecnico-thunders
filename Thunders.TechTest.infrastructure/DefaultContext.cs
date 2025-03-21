using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Thunders.TechTest.Domain.Entities;

namespace Thunders.TechTest.infrastructure;

public class DefaultContext : DbContext
{
    public DbSet<Toll> Tolls { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}

public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = configuration.GetConnectionString("ThundersTechTestDbPostgres");
        
        //mac container refused port 1341
        // builder.UseSqlServer(
        //     connectionString,
        //     b => b.MigrationsAssembly("Thunders.TechTest.infrastructure")
        // );
        
        builder.UseNpgsql(
            connectionString,
            b => b.MigrationsAssembly("Thunders.TechTest.infrastructure")
        );

        return new DefaultContext(builder.Options);
    }
}