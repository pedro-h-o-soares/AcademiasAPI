using System.Net;

namespace AcademiasAPI.Domain.Exceptions;

public class CustomBadRequestException : BaseException
{
    public CustomBadRequestException(string message) : base(message, HttpStatusCode.BadRequest)
    {
    }
}