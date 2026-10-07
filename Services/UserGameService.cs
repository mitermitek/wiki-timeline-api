using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Exceptions.DailyGame;
using wiki_timeline_api.Exceptions.UserGame;
using wiki_timeline_api.Mappers;
using wiki_timeline_api.Repositories.Interfaces;
using wiki_timeline_api.Services.Interfaces;

namespace wiki_timeline_api.Services;

public class UserGameService(IUserContextService userContextService, IUserGameRepository userGameRepository, IDailyGameRepository dailyGameRepository) : IUserGameService
{
    public async Task<UserGameResponse> CreateDailyUserGameAsync(CancellationToken cancellationToken)
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Now);
        var dailyGame = await dailyGameRepository.GetDailyGameByCreationDateAsync(todayDate, cancellationToken) ?? throw new DailyGameNotFoundException();

        var userId = userContextService.GetCurrentUserId();

        var userGamexists = await userGameRepository.DailyUserGameExistsAsync(userId, dailyGame.DailyGameID, cancellationToken);
        if (userGamexists)
        {
            throw new UserGameAlreadyExistsException();
        }

        var userGameToCreate = UserGameMapper.ToEntity(dailyGame.DailyGameID, userId);
        var createdUserGame = await userGameRepository.CreateUserGameAsync(userGameToCreate, cancellationToken);

        return createdUserGame.ToResponse();
    }

    public async Task<UserGameResponse> GetUserGameAsync(int userGameId, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetCurrentUserId();
        var userGame = await userGameRepository.GetUserGameAsync(userGameId, userId, cancellationToken) ?? throw new UserGameNotFoundException();

        return userGame.ToResponse();
    }
}