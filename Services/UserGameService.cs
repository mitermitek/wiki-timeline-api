using wiki_timeline_api.DTOs.Filters;
using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Exceptions.DailyGame;
using wiki_timeline_api.Exceptions.UserGame;
using wiki_timeline_api.Mappers;
using wiki_timeline_api.Repositories.Interfaces;
using wiki_timeline_api.Services.Interfaces;

namespace wiki_timeline_api.Services;

public class UserGameService(IUserContextService userContextService, IUserGameRepository userGameRepository, IDailyGameRepository dailyGameRepository) : IUserGameService
{
    private const int MAX_ATTEMPTS = 5;

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

    public async Task<PaginationResponse<UserGameResponse>> GetUserGamesAsync(PaginationFilter filter, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetCurrentUserId();
        var (userGames, totalCount) = await userGameRepository.GetUserGamesAsync(userId, filter.Page, filter.PageSize, cancellationToken);
        var items = userGames.Select(userGame => userGame.ToResponse()).ToList();
        var totalPages = totalCount / filter.PageSize + (totalCount % filter.PageSize == 0 ? 0 : 1);

        return new PaginationResponse<UserGameResponse>(items, filter.Page, filter.PageSize, totalCount, totalPages);
    }

    public async Task<UserGameResponse> GetUserGameAsync(int userGameId, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetCurrentUserId();
        var userGame = await userGameRepository.GetUserGameAsync(userGameId, userId, cancellationToken) ?? throw new UserGameNotFoundException();

        return userGame.ToResponse();
    }

    public async Task<UserGameResponse> CreateUserGameAttemptsAsync(int userGameId, List<int> userGameEntryIds, CancellationToken cancellationToken)
    {
        var userId = userContextService.GetCurrentUserId();
        var userGame = await userGameRepository.GetUserGameAsync(userGameId, userId, cancellationToken) ?? throw new UserGameNotFoundException();

        if (userGame.DailyGame?.CreationDate != DateOnly.FromDateTime(DateTime.Now))
        {
            throw new UserGameNotFoundException();
        }

        var userGameEntries = userGame.UserGameEntries.ToList();
        var attemptsCount = userGameEntries.Count(entry => entry.Order == 1);

        if (userGame.CompletedAt != null || attemptsCount >= MAX_ATTEMPTS)
        {
            throw new UserGameAlreadyCompletedException();
        }

        var dailyGameEntityIds = userGame.DailyGame?.DailyGameEntities.Select(dge => dge.DailyGameEntityID).ToList();
        var attemptsExists = userGameEntryIds.All(attemptId => dailyGameEntityIds!.Contains(attemptId));
        var duplicateAttempts = userGameEntryIds.GroupBy(attemptId => attemptId)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToList();

        if (!attemptsExists || duplicateAttempts.Count != 0 || userGameEntryIds.Count != dailyGameEntityIds?.Count)
        {
            throw new BadAttemptsException();
        }

        var userGameEntriesToCreate = userGameEntryIds.Select((userGameEntryId, index) => UserGameEntryMapper.ToEntity(userGame.UserGameID, userGameEntryId, index + 1)).ToList();

        foreach (var entryToCreate in userGameEntriesToCreate)
        {
            userGame.UserGameEntries.Add(entryToCreate);
        }

        var entityYears = userGame.DailyGame!.DailyGameEntities.ToDictionary(dailyGameEntity => dailyGameEntity.DailyGameEntityID, dailyGameEntity => dailyGameEntity.Entity!.Year);
        var attemptYears = userGameEntryIds.Select(entryId => entityYears[entryId]).ToList();
        var isChronological = attemptYears.SequenceEqual(attemptYears.OrderBy(year => year));

        if (isChronological || attemptsCount + 1 == MAX_ATTEMPTS)
        {
            var completedAt = DateTime.Now;
            userGame.CompletedAt = completedAt;
            userGame.Score = CalculateScore(attemptsCount + 1, userGame.StartedAt, completedAt);
            userGame.User?.TotalScore += userGame.Score.Value;
        }

        var updatedUserGame = await userGameRepository.UpdateUserGameAsync(userGame, cancellationToken);

        return updatedUserGame.ToResponse();
    }

    private static int CalculateScore(int attemptsCount, DateTime startedAt, DateTime completedAt)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(attemptsCount);

        var elapsedSeconds = Math.Max(0, (completedAt - startedAt).TotalSeconds);
        var timePenalty = (long)Math.Floor(elapsedSeconds / 10);
        var score = 1000L - 200L * (attemptsCount - 1) - timePenalty;

        return (int)Math.Max(0, score);
    }
}