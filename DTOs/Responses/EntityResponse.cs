namespace wiki_timeline_api.DTOs.Responses;

public record EntityResponse
{
    public int ID { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required ThemeResponse Theme { get; set; }
}
