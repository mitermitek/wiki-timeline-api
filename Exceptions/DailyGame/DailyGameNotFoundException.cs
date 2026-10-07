namespace wiki_timeline_api.Exceptions.DailyGame;

public class DailyGameNotFoundException : Exception
{
    public DailyGameNotFoundException() : base("Daily game not found.") { }
    public DailyGameNotFoundException(string message) : base(message) { }
    public DailyGameNotFoundException(string message, Exception inner) : base(message, inner) { }
}