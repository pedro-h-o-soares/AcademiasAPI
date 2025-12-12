using System.Net;

namespace AcademiasAPI.Domain.Exceptions;

public class EmptyFileException : BaseException
{
    public EmptyFileException() 
        : base("The sent file is empty", HttpStatusCode.BadRequest)
    {
    }
}