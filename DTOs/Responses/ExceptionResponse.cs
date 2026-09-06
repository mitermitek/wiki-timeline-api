namespace wiki_timeline_api.DTOs.Responses;

public record ExceptionResponse
{
    public required string Message { get; init; }
    public required string Type { get; init; }
}