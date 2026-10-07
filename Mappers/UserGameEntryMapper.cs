using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Mappers;

public static class UserGameEntryMapper
{
    public static UserGameEntryResponse ToResponse(this UserGameEntry entity, bool revealYear = false)
    {
        return new UserGameEntryResponse
        {
            ID = entity.UserGameID,
            Entity = entity.DailyGameEntity!.Entity!.ToResponse(revealYear),
            Order = entity.Order
        };
    }

    public static UserGameEntry ToEntity(int userGameId, int dailyGameEntityId, int order)
    {
        return new UserGameEntry
        {
            UserGameID = userGameId,
            DailyGameEntityID = dailyGameEntityId,
            Order = order
        };
    }
}
