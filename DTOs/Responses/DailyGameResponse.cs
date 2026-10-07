namespace wiki_timeline_api.DTOs.Responses;

public record DailyGameResponse
{
    public int ID { get; set; }
    public required DateOnly CreationDate { get; set; }
    public required ThemeResponse Theme { get; set; }
    public required List<EntityResponse> Entities { get; set; }
}
