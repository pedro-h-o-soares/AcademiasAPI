using System.Net;

namespace AcademiasAPI.Domain.Exceptions;

public class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; set; }

    public BaseException(string message, HttpStatusCode statusCode) 
        : base(message)
    {
        StatusCode = statusCode;
    }
}