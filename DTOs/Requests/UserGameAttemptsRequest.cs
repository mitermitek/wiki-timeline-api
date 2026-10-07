using System.ComponentModel.DataAnnotations;

namespace wiki_timeline_api.DTOs.Requests;

public record UserGameAttemptsRequest
{
    [Required]
    public required List<int> Attempts { get; init; }
}
