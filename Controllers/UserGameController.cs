using wiki_timeline_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace wiki_timeline_api.Controllers;

[Route("api/user-games")]
[ApiController]
[Authorize]
public class UserGameController(IUserGameService userGameService) : ControllerBase
{
    [HttpPost("daily")]
    public async Task<IActionResult> CreateDailyUserGame(CancellationToken cancellationToken)
    {
        var createdUserGame = await userGameService.CreateDailyUserGameAsync(cancellationToken);
        return CreatedAtAction(nameof(GetUserGame), new { userGameId = createdUserGame.ID }, createdUserGame);
    }

    [HttpGet("{userGameId}")]
    public async Task<IActionResult> GetUserGame(int userGameId, CancellationToken cancellationToken)
    {
        var userGame = await userGameService.GetUserGameAsync(userGameId, cancellationToken);
        return Ok(userGame);
    }
}