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

    public async Task<bool> DailyGameEntitiesExistAsync(int dailyGameId, List<int> dailyGameEntityIds, CancellationToken cancellationToken)
    {
        var existingEntityIds = await context.DailyGameEntities
            .Where(dge => dge.DailyGameID == dailyGameId && dailyGameEntityIds.Contains(dge.DailyGameEntityID))
            .Select(dge => dge.DailyGameEntityID)
            .ToListAsync(cancellationToken);

        return existingEntityIds.Count == dailyGameEntityIds.Count;
    }
}