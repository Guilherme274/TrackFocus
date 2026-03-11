using System.ComponentModel.DataAnnotations;

namespace TrackFocus.Application.DTOs.Request
{
    public record SerieRequest([Required] int Repeticoes,[Required] int Peso);
}