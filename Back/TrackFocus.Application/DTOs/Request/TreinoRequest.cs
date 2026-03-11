using System.ComponentModel.DataAnnotations;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.DTOs.Request
{
    public record TreinoRequest([Required] DateOnly DataTreino, [MinLength(1, ErrorMessage = "O treino deve ter no mínimo um exercício")] List<ExercicioRequest> Exercicios);
}