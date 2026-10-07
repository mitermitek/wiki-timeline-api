using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Mappers;

public static class UserGameMapper
{
    public static UserGameResponse ToResponse(this UserGame entity)
    {
        var revealYear = entity.CompletedAt.HasValue;

        return new UserGameResponse
        {
            ID = entity.UserGameID,
            StartedAt = entity.StartedAt,
            CompletedAt = entity.CompletedAt,
            DailyGame = entity.DailyGame!.ToResponse(revealYear),
            Entries = entity.UserGameEntries.Select(uge => uge.ToResponse(revealYear)).ToList()
        };
    }

    public static UserGame ToEntity(int dailyGameId, int userId)
    {
        return new UserGame
        {
            DailyGameID = dailyGameId,
            UserID = userId,
            StartedAt = DateTime.Now
        };
    }
}
