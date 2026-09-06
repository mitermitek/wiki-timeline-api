using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Repositories.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Checks if a user with the given username or email already exists in the database.
    /// </summary>
    /// <param name="username"></param>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsUserAlreadyExistsAsync(string username, string email, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a user by their username from the database.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new user in the database.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> CreateUserAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a user by their unique identifier (ID) from the database.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User?> GetUserByIdAsync(int userId, CancellationToken cancellationToken);
}