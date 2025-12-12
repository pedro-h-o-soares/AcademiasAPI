using AcademiasAPI.Domain.Dto.Exercicio;
using AcademiasAPI.Domain.Models;
using AutoMapper;

namespace AcademiasAPI.Infrastructure.CrossCutting.AutoMapper;

public class ExercicioProfile : Profile
{
    public ExercicioProfile()
    {
        CreateMap<Exercicio, ReadExercicioDto>();
        CreateMap<CreateExercicioDto, Exercicio>();
    }
}