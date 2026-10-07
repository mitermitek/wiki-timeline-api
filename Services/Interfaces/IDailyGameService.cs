using wiki_timeline_api.DTOs.Responses;

namespace wiki_timeline_api.Services.Interfaces;

public interface IDailyGameService
{
    /// <summary>
    /// Gets the daily game for today.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DailyGameResponse> GetTodayDailyGameAsync(CancellationToken cancellationToken);
}