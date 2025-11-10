using Application.DTOs;

namespace Cliente.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto);
        Task LogoutAsync();
        Task<bool> IsAuthenticatedAsync();
    }
}