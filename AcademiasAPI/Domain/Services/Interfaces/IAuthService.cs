namespace AcademiasAPI.Domain.Services.Interfaces;

public interface IAuthService
{
    public void SetAcademiaUsuarioContext(Guid academiaId);
    public void SetUsuarioContext(Guid usuarioId);
}