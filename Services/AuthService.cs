using System.Security.Claims;
using wiki_timeline_api.Entities;
using wiki_timeline_api.Exceptions.Auth;
using wiki_timeline_api.Exceptions.Context;
using wiki_timeline_api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.DTOs.Requests;
using wiki_timeline_api.Repositories.Interfaces;
using wiki_timeline_api.Exceptions.User;
using wiki_timeline_api.Mappers;
using Microsoft.AspNetCore.Identity;

namespace wiki_timeline_api.Services;

public class AuthService(IHttpContextAccessor httpContextAccessor, IUserContextService userContextService, IPasswordHasher<User> passwordHasher, IUserRepository userRepository) : IAuthService
{
    public async Task<UserResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var isUserAlreadyExists = await userRepository.IsUserAlreadyExistsAsync(request.Username, request.Email, cancellationToken);
        if (isUserAlreadyExists)
        {
            throw new UserAlreadyExistsException();
        }

        var user = request.ToEntity();
        user.PasswordHash = passwordHasher.HashPassword(user, request.Password);

        var createdUser = await userRepository.CreateUserAsync(user, cancellationToken);

        return createdUser.ToResponse();
    }

    public async Task<UserResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetUserByEmailAsync(request.Email, cancellationToken);
        if (existingUser is null || !VerifyUserPassword(existingUser, request.Password))
        {
            throw new BadCredentialsException();
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, existingUser.UserID.ToString()),
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = request.RememberMe,
            AllowRefresh = true
        };

        var HttpContext = httpContextAccessor.HttpContext ?? throw new HttpContextException();
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

        return existingUser.ToResponse();
    }

    public async Task LogoutAsync()
    {
        var HttpContext = httpContextAccessor.HttpContext ?? throw new HttpContextException();
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public async Task<UserResponse> GetCurrentUserAsync(CancellationToken cancellationToken)
    {
        var userId = userContextService.GetCurrentUserId();
        var currentUser = await userRepository.GetUserByIdAsync(userId, cancellationToken) ?? throw new UserNotFoundException();

        return currentUser.ToResponse();
    }

    /// <summary>
    /// Verifies the user's password against the stored password hash.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    private bool VerifyUserPassword(User user, string password)
    {
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        return verificationResult == PasswordVerificationResult.Success;
    }
}
