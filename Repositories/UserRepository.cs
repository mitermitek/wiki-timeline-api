using Microsoft.EntityFrameworkCore;
using wiki_timeline_api.Data;
using wiki_timeline_api.Entities;
using wiki_timeline_api.Repositories.Interfaces;

namespace wiki_timeline_api.Repositories;

public class UserRepository(WikiTimelineContext context) : IUserRepository
{
    public async Task<bool> IsUserAlreadyExistsAsync(string username, string email, CancellationToken cancellationToken)
    {
        return await context.Users.AnyAsync(u => u.Username == username || u.Email == email, cancellationToken);
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async Task<User?> GetUserByIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.UserID == userId, cancellationToken);
    }
}