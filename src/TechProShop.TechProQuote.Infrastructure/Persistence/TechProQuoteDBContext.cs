using Microsoft.EntityFrameworkCore;
using TechProShop.TechProQuote.Domain.Entities;

namespace TechProShop.TechProQuote.Infrastructure.Persistence;

public class TechProQuoteDbContext : DbContext
{
    public TechProQuoteDbContext(DbContextOptions<TechProQuoteDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(b =>
        {
            b.HasKey(c => c.Id);
            b.Property(c => c.Nom).IsRequired().HasMaxLength(200);
            b.Property(c => c.Email).IsRequired().HasMaxLength(200);
            b.HasIndex(c => c.Email).IsUnique();
        });
    }
        
}
