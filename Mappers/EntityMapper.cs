using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Mappers;

public static class EntityMapper
{
    public static EntityResponse ToResponse(this Entity entity, bool revealYear = false)
    {
        return new EntityResponse
        {
            ID = entity.EntityID,
            Title = entity.Title,
            Description = entity.Description,
            Year = revealYear ? entity.Year : null,
            DateType = entity.DateType,
            Theme = entity.Theme!.ToResponse()
        };
    }
}
