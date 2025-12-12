using AcademiasAPI.Domain.Dto.Auth;
using AcademiasAPI.Domain.Dto.Usuario;
using AcademiasAPI.Domain.Exceptions;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using AutoMapper;

namespace AcademiasAPI.Domain.Services;

public class UsuarioService(IUsuarioRep rep, IMapper mapper, IDireitoRep direitoRep) 
    : BaseService<Usuario, ReadUsuarioDto, CreateUsuarioDto>(rep, mapper), 
        IUsuarioService
{
    public override ReadUsuarioDto Create(CreateUsuarioDto createDto)
    {
        if (createDto.Senha != createDto.ConfirmaSenha)
        {
            throw new CustomBadRequestException("Os campos [senha] e [confirmaSenha] devem ser iguais");
        }

        if (rep.GetByEmail(createDto.Email) is not null)
        {
            throw new CustomConflictException("Esse email já está em uso");
        }
        
        var entity = mapper.Map<Usuario>(createDto);
        if (createDto.Direitos is not null && createDto.Direitos.Count != 0)
        {
            entity.Direitos = direitoRep.GetById(createDto.Direitos.ToArray());
        }
        
        return base.Create(entity);
    }

    public ReadUsuarioDto AutenticaUsuario(LoginDto dto)
    {
        var usuario = rep.GetByEmailESenha(dto.Email, dto.Senha);
        if (usuario is null)
        {
            throw new CustomUnauthorizedException("Usuário ou senha inválidos");
        }
        
        return mapper.Map<ReadUsuarioDto>(usuario);
    }
}