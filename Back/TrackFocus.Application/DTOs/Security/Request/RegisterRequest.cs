using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TrackFocus.Application.DTOs.Security.Request
{
    public record RegisterRequest
    (
        [Required]
        string Username,
        [Required]
        string Email,
        [Required]
        [DataType(DataType.Password)]
        string Password,
        [Required]
        [property:Compare("Password")]
        string RepeatPassword,
        [Required]
        DateTime DataNascimento
    );
}