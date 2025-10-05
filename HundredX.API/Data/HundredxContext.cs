using Microsoft.EntityFrameworkCore;
using HundredX.API.Models;

namespace HundredX.API.Data;

public class HundredxContext : DbContext
{
    public HundredxContext(DbContextOptions<HundredxContext> options)
        : base(options) { }

    // DbSet representing the table
    public DbSet<HistoricalRecord> HistoricalRecords => Set<HistoricalRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use the "hundredx" schema by default
        modelBuilder.HasDefaultSchema("hundredx");

        modelBuilder.Entity<HistoricalRecord>(e =>
        {
            // Map to the correct table
            e.ToTable("historical_record");

            // Composite PK
            e.HasKey(hr => new { hr.CryptocurrencyId, hr.RecordDate });

            // Precision settings
            e.Property(hr => hr.Price).HasPrecision(38, 28);
            e.Property(hr => hr.Supply).HasPrecision(38, 20);
            e.Property(hr => hr.Volume).HasPrecision(38, 20);
            e.Property(hr => hr.MarketCap).HasPrecision(38, 20);
        });
    }
}
