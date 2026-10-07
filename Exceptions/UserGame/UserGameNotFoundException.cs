namespace wiki_timeline_api.Exceptions.UserGame;

public class UserGameNotFoundException : Exception
{
    public UserGameNotFoundException() : base("User game not found.") { }
    public UserGameNotFoundException(string message) : base(message) { }
    public UserGameNotFoundException(string message, Exception inner) : base(message, inner) { }
}