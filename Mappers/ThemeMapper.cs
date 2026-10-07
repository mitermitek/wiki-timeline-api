using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Mappers;

public static class ThemeMapper
{
    public static ThemeResponse ToResponse(this Theme entity)
    {
        return new ThemeResponse
        {
            ID = entity.ThemeID,
            Name = entity.Name
        };
    }
}
