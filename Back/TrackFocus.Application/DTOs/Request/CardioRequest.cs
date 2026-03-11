using System.ComponentModel.DataAnnotations;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.DTOs.Request
{
    public record CardioRequest([Required] int Distancia, [Required] int Calorias);
}