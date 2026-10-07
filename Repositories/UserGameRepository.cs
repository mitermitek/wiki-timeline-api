using Microsoft.EntityFrameworkCore;
using wiki_timeline_api.Data;
using wiki_timeline_api.Entities;
using wiki_timeline_api.Repositories.Interfaces;

namespace wiki_timeline_api.Repositories;

public class UserGameRepository(WikiTimelineContext context) : IUserGameRepository
{
    public async Task<bool> DailyUserGameExistsAsync(int userId, int dailyGameId, CancellationToken cancellationToken)
    {
        return await context.UserGames.AnyAsync(ug => ug.UserID == userId && ug.DailyGameID == dailyGameId, cancellationToken);
    }

    public async Task<UserGame> CreateUserGameAsync(UserGame userGame, CancellationToken cancellationToken)
    {
        context.UserGames.Add(userGame);
        await context.SaveChangesAsync(cancellationToken);

        return userGame;
    }

    public async Task<UserGame?> GetUserGameAsync(int userGameId, int userId, CancellationToken cancellationToken)
    {
        return await context.UserGames
            .Include(ug => ug.DailyGame)
                .ThenInclude(dg => dg!.DailyGameEntities)
                    .ThenInclude(dge => dge.Entity)
                        .ThenInclude(e => e!.Theme)
            .Include(ug => ug.UserGameEntries)
                .ThenInclude(uge => uge.DailyGameEntity)
                    .ThenInclude(dge => dge!.Entity)
                        .ThenInclude(e => e!.Theme)
            .Include(ug => ug.User)
            .FirstOrDefaultAsync(ug => ug.UserGameID == userGameId && ug.UserID == userId, cancellationToken);
    }

    public async Task<UserGame> UpdateUserGameAsync(UserGame userGame, CancellationToken cancellationToken)
    {
        context.UserGames.Update(userGame);
        await context.SaveChangesAsync(cancellationToken);

        return userGame;
    }
}