using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Mappers;

public static class EntityMapper
{
    public static EntityResponse ToResponse(this Entity entity)
    {
        return new EntityResponse
        {
            ID = entity.ThemeID,
            Title = entity.Title,
            Description = entity.Description,
            DateType = entity.DateType,
            Theme = entity.Theme!.ToResponse()
        };
    }
}
