namespace wiki_timeline_api.Exceptions.DailyGame;

public class BadAttemptsException : Exception
{
    public BadAttemptsException() : base("Bad attempts.") { }
    public BadAttemptsException(string message) : base(message) { }
    public BadAttemptsException(string message, Exception inner) : base(message, inner) { }
}