using Microsoft.EntityFrameworkCore;
using wiki_timeline_api.Data;
using wiki_timeline_api.Entities;
using wiki_timeline_api.Repositories.Interfaces;

namespace wiki_timeline_api.Repositories;

public class DailyGameRepository(WikiTimelineContext context) : IDailyGameRepository
{
    public async Task<DailyGame?> GetDailyGameByCreationDateAsync(DateOnly creationDate, CancellationToken cancellationToken)
    {
        return await context.DailyGames
            .Include(dg => dg.DailyGameEntities)
                .ThenInclude(dge => dge.Entity)
                    .ThenInclude(e => e!.Theme)
            .FirstOrDefaultAsync(dg => dg.CreationDate == creationDate, cancellationToken);
    }
}