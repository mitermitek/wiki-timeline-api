using wiki_timeline_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wiki_timeline_api.Enums;

namespace wiki_timeline_api.Data;

public class WikiTimelineContext(DbContextOptions<WikiTimelineContext> opt) : DbContext(opt)
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserGame> UserGames { get; set; }
    public DbSet<UserGameEntry> UserGameEntries { get; set; }
    public DbSet<DailyGame> DailyGames { get; set; }
    public DbSet<DailyGameEntity> DailyGameEntities { get; set; }
    public DbSet<Entity> Entities { get; set; }
    public DbSet<Theme> Themes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity>().Property(e => e.DateType).HasConversion(new EnumToStringConverter<DateType>());
        var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime));

        modelBuilder.Entity<DailyGame>()
            .Property(d => d.CreationDate)
            .HasConversion(dateOnlyConverter)
            .HasColumnType("date");
        modelBuilder.Entity<Entity>()
            .Property(e => e.LastUsedAt)
            .HasConversion(dateOnlyConverter)
            .HasColumnType("date");
    }
}