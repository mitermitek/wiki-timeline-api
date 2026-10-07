namespace wiki_timeline_api.DTOs.Responses;

public record LeaderboardEntryResponse
{
    public int Rank { get; set; }
    public required string Username { get; set; }
    public long TotalScore { get; set; }
}