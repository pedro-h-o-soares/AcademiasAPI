using AcademiasAPI.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AcademiasAPI.Presentation.Middlewares;

public class HttpExceptionHandler(ILogger<HttpExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails();
        problemDetails.Instance = httpContext.Request.Path;

        if (exception is BaseException e)
        {
            problemDetails.Status = (int)e.StatusCode;
            httpContext.Response.StatusCode = (int)e.StatusCode;
            problemDetails.Title = e.Message;
        }
        else
        {
            problemDetails.Title = "Erro interno no servidor";
            problemDetails.Status = StatusCodes.Status500InternalServerError;
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            logger.LogError(exception, exception.Message);
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        
        return true;
    }
}