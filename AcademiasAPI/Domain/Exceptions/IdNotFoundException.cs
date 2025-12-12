using System.Net;

namespace AcademiasAPI.Domain.Exceptions;

public class IdNotFoundException : BaseException
{
    public IdNotFoundException(string item, Guid id) 
        : base($"{item} com ID [{id}] não encontrado", HttpStatusCode.NotFound)
    {
    }
}