using AcademiasAPI.Domain.Dto.ExercicioSerie;
using AcademiasAPI.Domain.Dto.Serie;
using AcademiasAPI.Domain.Exceptions;
using AcademiasAPI.Domain.Models;
using AcademiasAPI.Domain.Services.Interfaces;
using AcademiasAPI.Infrastructure.Repositories.Interfaces;
using AutoMapper;

namespace AcademiasAPI.Domain.Services;

public class SerieService(ISerieRep rep, IMapper mapper) 
    : BaseService<Serie, ReadSerieDto, CreateSerieDto>(rep, mapper),
        ISerieService
{
    public void CreateExercicio(Guid id, CreateExercicioSerieDto dto)
    {
        var exercicio = mapper.Map<ExercicioSerie>(dto);

        rep.CreateExercicio(id, exercicio);
    }

    public void RemoveExercicio(Guid id, Guid exercicioId)
    {
        var serie = rep.GetById(id);
        if (serie is null)
        {
            throw new IdNotFoundException("Serie", id);
        }

        if (serie.Exercicios.FirstOrDefault(e => e.Id == exercicioId) is null)
        {
            throw new IdNotFoundException("Exercicio", exercicioId);
        }

        rep.RemoveExercicio(exercicioId);
    }
}