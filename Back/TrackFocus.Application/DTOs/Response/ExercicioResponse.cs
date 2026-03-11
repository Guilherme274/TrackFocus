using TrackFocus.Application.DTOs.Request;

namespace TrackFocus.Application.DTOs.Response
{
    public record ExercicioResponse(int Id, string Nome, int Tipo_ExercicioId, int TreinoId, List<CardioResponse> ExerciciosCardio, List<SerieResponse> ExerciciosMusculacao);
}