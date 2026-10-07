using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Repositories.Interfaces;

public interface IUserGameRepository
{
    /// <summary>
    /// Checks if a daily user game exists for a given user and daily game ID.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="dailyGameId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DailyUserGameExistsAsync(int userId, int dailyGameId, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new user game.
    /// </summary>
    /// <param name="userGame"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserGame> CreateUserGameAsync(UserGame userGame, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a user game by its ID and the associated user ID.
    /// </summary>
    /// <param name="userGameId"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserGame?> GetUserGameAsync(int userGameId, int userId, CancellationToken cancellationToken);
}