using System.ComponentModel.DataAnnotations;

namespace wiki_timeline_api.DTOs.Requests;

public record LoginRequest
{
    [Required]
    public required string Email { get; init; }

    [Required]
    public required string Password { get; init; }

    public bool RememberMe { get; init; } = false;
}
