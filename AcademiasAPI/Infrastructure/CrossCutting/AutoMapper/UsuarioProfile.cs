using AcademiasAPI.Domain.Dto.Usuario;
using AcademiasAPI.Domain.Models;
using AutoMapper;

namespace AcademiasAPI.Infrastructure.CrossCutting.AutoMapper;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<Usuario, ReadUsuarioDto>();
        CreateMap<CreateUsuarioDto, Usuario>().ForMember(
            u => u.Direitos, opts => 
                opts.Ignore());
    }
}