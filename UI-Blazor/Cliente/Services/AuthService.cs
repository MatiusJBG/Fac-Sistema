using Application.DTOs;
using System.Net.Http.Json;

namespace Cliente.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", dto);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al iniciar sesión: {ex.Message}");
                return null;
            }
        }

        public async Task LogoutAsync()
        {
            await Task.CompletedTask;
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            return await Task.FromResult(false);
        }
    }
}