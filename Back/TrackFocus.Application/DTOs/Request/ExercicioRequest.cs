using System.ComponentModel.DataAnnotations;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.DTOs.Request
{
    public record ExercicioRequest([Required] string Nome, [Required] int Tipo_ExercicioId, [Required] List<CardioRequest>? ExerciciosCardio, [Required] List<SerieRequest>? ExerciciosMusculacao);
}