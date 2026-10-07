using System.ComponentModel.DataAnnotations;

namespace wiki_timeline_api.DTOs.Filters;

public class PaginationFilter
{
    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;

    [Range(1, 50)]
    public int PageSize { get; set; } = 20;
}
