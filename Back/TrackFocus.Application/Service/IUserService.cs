using TrackFocus.Application.DTOs.Security.Request;
using TrackFocus.Application.DTOs.Security.Response;

namespace TrackFocus.Application.Service
{
    public interface IUserService
    {
        public Task<string> RegisterUserAsync(RegisterRequest request);
        public Task<LoginResponse>LoginUserAsync(LoginRequest request);
    }
}