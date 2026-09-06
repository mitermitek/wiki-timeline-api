namespace wiki_timeline_api.DTOs.Responses;

public record UserResponse
{
    public int ID { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
}
