using wiki_timeline_api.DTOs.Requests;
using wiki_timeline_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace wiki_timeline_api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest, CancellationToken cancellationToken)
    {
        var registeredUser = await authService.RegisterAsync(registerRequest, cancellationToken);
        return CreatedAtAction(nameof(GetCurrentUser), registeredUser);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
    {
        var loggedInUser = await authService.LoginAsync(loginRequest, cancellationToken);
        return Ok(loggedInUser);
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser(CancellationToken cancellationToken)
    {
        var currentUser = await authService.GetCurrentUserAsync(cancellationToken);
        return Ok(currentUser);
    }

    [HttpDelete("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return NoContent();
    }
}