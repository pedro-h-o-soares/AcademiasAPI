using System.Net;

namespace AcademiasAPI.Domain.Exceptions;

public class InvalidFileExtensionException : BaseException
{
    public InvalidFileExtensionException() 
        : base("Tipo de arquivo inválido", HttpStatusCode.BadRequest)
    {
    }
}