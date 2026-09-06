using System.Security.Claims;
using wiki_timeline_api.Exceptions.Context;
using wiki_timeline_api.Services.Interfaces;

namespace wiki_timeline_api.Services;

public class UserContextService(IHttpContextAccessor httpContextAccessor) : IUserContextService
{
    public int GetCurrentUserId()
    {
        var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim is null || !int.TryParse(userIdClaim, out var userId))
        {
            throw new HttpContextException("Unable to retrieve current user ID from HTTP context.");
        }

        return userId;
    }
}
