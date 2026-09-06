using wiki_timeline_api.DTOs.Requests;
using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Entities;

namespace wiki_timeline_api.Mappers;

public static class UserMapper
{
    public static User ToEntity(this RegisterRequest request)
    {
        return new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = string.Empty // Password will be hashed and set in the service layer
        };
    }

    public static UserResponse ToResponse(this User entity)
    {
        return new UserResponse
        {
            ID = entity.UserID,
            Username = entity.Username,
            Email = entity.Email
        };
    }
}
