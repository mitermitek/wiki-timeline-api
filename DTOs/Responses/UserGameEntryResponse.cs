namespace wiki_timeline_api.DTOs.Responses;

public record UserGameEntryResponse
{
    public int ID { get; set; }
    public required EntityResponse Entity { get; set; }
    public int Order { get; set; }
}
