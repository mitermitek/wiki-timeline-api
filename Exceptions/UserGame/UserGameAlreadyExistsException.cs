namespace wiki_timeline_api.Exceptions.UserGame;

public class UserGameAlreadyExistsException : Exception
{
    public UserGameAlreadyExistsException() : base("User game already exists.") { }
    public UserGameAlreadyExistsException(string message) : base(message) { }
    public UserGameAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
}