using Application.DTOs;
using Application.Interfaces;
using System.Net.Http.Json;

namespace Cliente.Services
{
    public class FacturaHttpService : Application.Interfaces.IFacturaService
    {
        private readonly HttpClient _httpClient;

        public FacturaHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<FacturaDto>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<FacturaDto>>("api/facturas");
            return result ?? new List<FacturaDto>();
        }

        public async Task<FacturaDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<FacturaDto>($"api/facturas/{id}");
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<FacturaDto> CreateAsync(CreateFacturaDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/facturas", dto);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<FacturaDto>();
            if (result == null)
                throw new Exception("No se pudo crear la factura");
            return result;
        }

        public async Task<IEnumerable<FacturaDto>> GetByClienteAsync(string cedula)
        {
            var result = await _httpClient.GetFromJsonAsync<List<FacturaDto>>($"api/facturas/cliente/{cedula}");
            return result ?? new List<FacturaDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/facturas/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}