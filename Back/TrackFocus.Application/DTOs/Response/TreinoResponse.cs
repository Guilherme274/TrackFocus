using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.DTOs.Response
{
    public record TreinoResponse(int Id, string UserId, DateOnly DataTreino, List<Exercicio> Exercicios);
}