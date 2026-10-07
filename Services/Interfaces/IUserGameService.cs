using wiki_timeline_api.DTOs.Responses;

namespace wiki_timeline_api.Services.Interfaces;

public interface IUserGameService
{
    /// <summary>
    /// Creates a new daily user game.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserGameResponse> CreateDailyUserGameAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a user game by its ID.
    /// </summary>
    /// <param name="userGameId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserGameResponse> GetUserGameAsync(int userGameId, CancellationToken cancellationToken);
}