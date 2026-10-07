using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Exceptions.DailyGame;
using wiki_timeline_api.Mappers;
using wiki_timeline_api.Repositories.Interfaces;
using wiki_timeline_api.Services.Interfaces;

namespace wiki_timeline_api.Services;

public class DailyGameService(IDailyGameRepository dailyGameRepository) : IDailyGameService
{
    public async Task<DailyGameResponse> GetTodayDailyGameAsync(CancellationToken cancellationToken)
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Now);
        var dailyGame = await dailyGameRepository.GetDailyGameByCreationDateAsync(todayDate, cancellationToken) ?? throw new DailyGameNotFoundException();

        return dailyGame.ToResponse();
    }
}