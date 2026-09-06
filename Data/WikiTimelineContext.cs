using wiki_timeline_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace wiki_timeline_api.Data;

public class WikiTimelineContext(DbContextOptions<WikiTimelineContext> opt) : DbContext(opt)
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserGame> UserGames { get; set; }
    public DbSet<DailyGame> DailyGames { get; set; }
    public DbSet<DailyGameCard> DailyGameCards { get; set; }
}