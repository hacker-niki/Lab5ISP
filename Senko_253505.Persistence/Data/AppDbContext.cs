using Microsoft.EntityFrameworkCore;
using Senko_253505.Domain.Entities;

namespace Senko_253505.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    private DbSet<Car> Cars { get; }
    private DbSet<TransportCompany> TransportCompanies { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .OwnsOne(t => t.Characteristic);
    }
}