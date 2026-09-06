using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.DTOs.Requests;

namespace wiki_timeline_api.Services.Interfaces;

public interface IAuthService
{
    /// <summary>
    /// Registers a new user with the provided registration request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Logs in a user with the provided login request and returns a user response containing authentication details.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Logs out the currently authenticated user and invalidates their authentication session.
    /// </summary>
    /// <returns></returns>
    Task LogoutAsync();

    /// <summary>
    /// Retrieves the currently authenticated user's information.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserResponse> GetCurrentUserAsync(CancellationToken cancellationToken);
}
