namespace wiki_timeline_api.Services.Interfaces;

public interface IUserContextService
{
    /// <summary>
    /// Gets the current user id from the context.
    /// </summary>
    /// <returns></returns>
    int GetCurrentUserId();
}
