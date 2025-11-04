using System.Net.Http;
using System.Net.Http.Json;
using Client.Models;

namespace Client.Services
{
    public class AuthApiService 
    {
        private readonly HttpClient _http;
        public AuthApiService(HttpClient http) 
        {
            _http = http;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", dto);
            return await response.Content.ReadFromJsonAsync<LoginResponseDto>();
        }
    }
}