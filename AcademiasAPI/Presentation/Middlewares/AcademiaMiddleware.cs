using System.Security.Claims;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Presentation.Constants;

namespace AcademiasAPI.Presentation.Middlewares;

public class AcademiaMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var authService = context.RequestServices.GetRequiredService<IAuthService>();
        
        var usuarioId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(usuarioId))
        {
            authService.SetUsuarioContext(Guid.Parse(usuarioId));
        }
        else
        {
            var academiaId = context.Request.Headers[Headers.AcademiaHeader].ToString();
            if (!string.IsNullOrEmpty(academiaId)) 
                authService.SetAcademiaUsuarioContext(Guid.Parse(academiaId));
        }
        
        await next(context);
    }
}

public static class RequestAcademiaMiddlewareExtensions
{
    public static IApplicationBuilder UseAcademiaProperty(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AcademiaMiddleware>();
    }
}