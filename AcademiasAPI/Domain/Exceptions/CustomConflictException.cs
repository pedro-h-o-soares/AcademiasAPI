using System.Net;

namespace AcademiasAPI.Domain.Exceptions;

public class CustomConflictException : BaseException
{
    public CustomConflictException(string message) : base(message, HttpStatusCode.Conflict)
    {
    }
}