using System.Net;

namespace Services.Exceptions;

public class EntityNotFoundException : DefaultException
{
    public EntityNotFoundException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.NotFound;
    }
}