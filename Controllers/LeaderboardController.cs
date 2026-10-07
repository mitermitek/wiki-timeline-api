using Microsoft.AspNetCore.Mvc;
using wiki_timeline_api.Services.Interfaces;

namespace wiki_timeline_api.Controllers;

[Route("api/leaderboard")]
[ApiController]
public class LeaderboardController(ILeaderboardService leaderboardService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetLeaderboard(CancellationToken cancellationToken)
    {
        var leaderboard = await leaderboardService.GetLeaderboardAsync(cancellationToken);
        return Ok(leaderboard);
    }
}