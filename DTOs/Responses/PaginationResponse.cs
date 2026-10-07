namespace wiki_timeline_api.DTOs.Responses;

public record PaginationResponse<T>(List<T> Items, int Page, int PageSize, int TotalCount, int TotalPages);
