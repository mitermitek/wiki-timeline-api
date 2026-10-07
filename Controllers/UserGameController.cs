using wiki_timeline_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wiki_timeline_api.DTOs.Filters;
using wiki_timeline_api.DTOs.Requests;

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

    [HttpGet]
    public async Task<IActionResult> GetUserGames([FromQuery] PaginationFilter filter, CancellationToken cancellationToken)
    {
        var userGames = await userGameService.GetUserGamesAsync(filter, cancellationToken);
        return Ok(userGames);
    }

    [HttpGet("{userGameId}")]
    public async Task<IActionResult> GetUserGame(int userGameId, CancellationToken cancellationToken)
    {
        var userGame = await userGameService.GetUserGameAsync(userGameId, cancellationToken);
        return Ok(userGame);
    }

    [HttpPost("{userGameId}/daily/attempts")]
    public async Task<IActionResult> CreateUserGameAttempts(int userGameId, [FromBody] UserGameAttemptsRequest request, CancellationToken cancellationToken)
    {
        var updatedUserGame = await userGameService.CreateUserGameAttemptsAsync(userGameId, request.Attempts, cancellationToken);
        return CreatedAtAction(nameof(GetUserGame), new { userGameId = updatedUserGame.ID }, updatedUserGame);
    }
}