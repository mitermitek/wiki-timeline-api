using wiki_timeline_api.DTOs.Responses;

namespace wiki_timeline_api.Services.Interfaces;

public interface ILeaderboardService
{
    /// <summary>
    /// Retrieves the top 50 users based on their total score for the leaderboard.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<LeaderboardEntryResponse>> GetLeaderboardAsync(CancellationToken cancellationToken);
}