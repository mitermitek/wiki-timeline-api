using wiki_timeline_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace wiki_timeline_api.Controllers;

[Route("api/daily-games")]
[ApiController]
[Authorize]
public class DailyGameController(IDailyGameService dailyGameService) : ControllerBase
{
    [HttpGet("today")]
    public async Task<IActionResult> CreateDailyUserGame(CancellationToken cancellationToken)
    {
        var dailyGame = await dailyGameService.GetTodayDailyGameAsync(cancellationToken);
        return Ok(dailyGame);
    }
}