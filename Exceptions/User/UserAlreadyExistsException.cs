namespace wiki_timeline_api.Exceptions.User;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException() : base("User already exists.") { }
    public UserAlreadyExistsException(string message) : base(message) { }
    public UserAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
}