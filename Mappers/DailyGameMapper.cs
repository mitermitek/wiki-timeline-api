using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Mappers;

public static class DailyGameMapper
{
    public static DailyGameResponse ToResponse(this DailyGame entity)
    {
        return new DailyGameResponse
        {
            ID = entity.DailyGameID,
            CreationDate = entity.CreationDate
        };
    }
}