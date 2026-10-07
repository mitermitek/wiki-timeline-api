using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Mappers;

public static class DailyGameMapper
{
    public static DailyGameResponse ToResponse(this DailyGame entity)
    {
        var firstEntity = entity.DailyGameEntities.FirstOrDefault()?.Entity;

        return new DailyGameResponse
        {
            ID = entity.DailyGameID,
            CreationDate = entity.CreationDate,
            Theme = firstEntity!.Theme!.ToResponse(),
            DateType = firstEntity!.DateType,
            Entities = [.. entity.DailyGameEntities.Select(dge => dge.Entity!.ToResponse())]
        };
    }
}