namespace wiki_timeline_api.Exceptions.Auth;

public class BadCredentialsException : Exception
{
    public BadCredentialsException() : base("Bad credentials.") { }
    public BadCredentialsException(string message) : base(message) { }
    public BadCredentialsException(string message, Exception inner) : base(message, inner) { }
}