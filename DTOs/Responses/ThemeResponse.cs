namespace wiki_timeline_api.DTOs.Responses;

public record ThemeResponse
{
    public int ID { get; set; }
    public required string Name { get; set; }
}
