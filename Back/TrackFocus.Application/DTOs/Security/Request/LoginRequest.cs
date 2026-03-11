using System.ComponentModel.DataAnnotations;

namespace TrackFocus.Application.DTOs.Security.Request
{
    public record LoginRequest([Required] string Email,[Required] string Password);
}