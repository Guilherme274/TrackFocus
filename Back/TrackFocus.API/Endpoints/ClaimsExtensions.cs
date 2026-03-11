using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal user)
    {
        // "NameIdentifier" é o padrão onde o Identity armazena o ID (sub no JWT)
        return user.FindFirst(ClaimTypes.NameIdentifier)?.Value 
               ?? user.FindFirst("sub")?.Value; 
    }
}