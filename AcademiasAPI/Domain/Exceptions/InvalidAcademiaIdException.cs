using System.Net;

namespace AcademiasAPI.Domain.Exceptions;

public class InvalidAcademiaIdException : BaseException
{
    public InvalidAcademiaIdException() : base("ID de academia inválido", HttpStatusCode.Unauthorized)
    {
    }
}