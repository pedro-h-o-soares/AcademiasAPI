using AcademiasAPI.Domain.Dto.ExercicioSerie;
using AcademiasAPI.Domain.Models;
using AutoMapper;

namespace AcademiasAPI.Infrastructure.CrossCutting.AutoMapper;

public class ExercicioSerieProfile : Profile
{
    public ExercicioSerieProfile()
    {
        CreateMap<ExercicioSerie, ReadExercicioSerieDto>();
        CreateMap<CreateExercicioSerieDto, ExercicioSerie>();
    }
}