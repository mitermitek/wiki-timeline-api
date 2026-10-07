using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Repositories.Interfaces;
using wiki_timeline_api.Services.Interfaces;

namespace wiki_timeline_api.Services;

public class LeaderboardService(IUserRepository userRepository) : ILeaderboardService
{
    public async Task<List<LeaderboardEntryResponse>> GetLeaderboardAsync(CancellationToken cancellationToken)
    {
        var leaderboardUsers = await userRepository.GetLeaderboardUsersAsync(cancellationToken);

        return [.. leaderboardUsers
            .Select((user, index) => new LeaderboardEntryResponse
            {
                Rank = index + 1,
                Username = user.Username,
                TotalScore = user.TotalScore
            })];
    }
}