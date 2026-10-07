using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Mappers;

public static class UserGameEntryMapper
{
    public static UserGameEntryResponse ToResponse(this UserGameEntry entity)
    {
        return new UserGameEntryResponse
        {
            ID = entity.UserGameID,
            Entity = entity.DailyGameEntity!.Entity!.ToResponse(),
            Order = entity.Order
        };
    }
}
