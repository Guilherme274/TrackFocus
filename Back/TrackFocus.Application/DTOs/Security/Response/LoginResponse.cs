namespace TrackFocus.Application.DTOs.Security.Response
{
    public record LoginResponse(string Id, string Email, string UserName, DateTime DataNascimento, string Token)
    {
        public LoginResponse() : this("", string.Empty, string.Empty, DateTime.MinValue, string.Empty) { }
    }
}