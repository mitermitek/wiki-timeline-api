using wiki_timeline_api.DTOs.Responses;
using wiki_timeline_api.Exceptions.Auth;
using wiki_timeline_api.Exceptions.DailyGame;
using wiki_timeline_api.Exceptions.User;
using wiki_timeline_api.Exceptions.UserGame;

namespace wiki_timeline_api.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var response = new ExceptionResponse
        {
            Message = exception.Message,
            Type = exception.GetType().Name
        };

        context.Response.StatusCode = exception switch
        {
            BadCredentialsException => StatusCodes.Status401Unauthorized,
            UserNotFoundException or UserGameNotFoundException or DailyGameNotFoundException => StatusCodes.Status404NotFound,
            UserAlreadyExistsException or UserGameAlreadyExistsException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };

        await context.Response.WriteAsJsonAsync(response);
    }
}
