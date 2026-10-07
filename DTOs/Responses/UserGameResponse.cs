namespace wiki_timeline_api.DTOs.Responses;

public record UserGameResponse
{
    public int ID { get; set; }
    public required DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public required DailyGameResponse DailyGame { get; set; }
}
