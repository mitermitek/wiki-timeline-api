using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Repositories.Interfaces;

public interface IDailyGameRepository
{
    /// <summary>
    /// Gets a DailyGame by creation date.
    /// </summary>
    /// <param name="creationDate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DailyGame?> GetDailyGameByCreationDateAsync(DateOnly creationDate, CancellationToken cancellationToken);
}