using System.Net;

namespace AcademiasAPI.Domain.Exceptions;

public class CustomUnauthorizedException : BaseException
{
    public CustomUnauthorizedException(string message) : base(message, HttpStatusCode.Unauthorized)
    {
    }
}