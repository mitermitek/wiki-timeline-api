namespace wiki_timeline_api.DTOs.Responses;

public record DailyGameResponse
{
    public int ID { get; set; }
    public required DateOnly CreationDate { get; set; }
}
