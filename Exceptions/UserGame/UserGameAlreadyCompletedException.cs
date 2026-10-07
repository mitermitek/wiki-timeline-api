namespace wiki_timeline_api.Exceptions.UserGame;

public class UserGameAlreadyCompletedException : Exception
{
    public UserGameAlreadyCompletedException() : base("User game already completed.") { }
    public UserGameAlreadyCompletedException(string message) : base(message) { }
    public UserGameAlreadyCompletedException(string message, Exception inner) : base(message, inner) { }
}