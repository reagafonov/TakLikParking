using System.Net;

namespace Services.Exceptions;

public abstract class DefaultException : Exception
{
    public HttpStatusCode StatusCode { get; init; }

    protected DefaultException(string message) : base(message)
    {
    }
}