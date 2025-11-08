using Application.DTOs;
using System.Net.Http.Json;

namespace Cliente.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly HttpClient _httpClient;

        public FacturaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FacturaDto>> GetAllAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<FacturaDto>>("api/facturas") ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener facturas: {ex.Message}");
                return new();
            }
        }

        public async Task<FacturaDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<FacturaDto>($"api/facturas/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener factura: {ex.Message}");
                return null;
            }
        }

        public async Task<FacturaDto> CreateAsync(CreateFacturaDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/facturas", dto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<FacturaDto>() ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear factura: {ex.Message}");
                throw;
            }
        }

        public async Task<List<FacturaDto>> GetByClienteAsync(string cedula)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<FacturaDto>>($"api/facturas/cliente/{cedula}") ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener facturas del cliente: {ex.Message}");
                return new();
            }
        }

        public async Task<List<FacturaDto>> GetByFechaRangoAsync(DateTime desde, DateTime hasta)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<FacturaDto>>(
                    $"api/facturas/fecha?desde={desde:yyyy-MM-dd}&hasta={hasta:yyyy-MM-dd}") ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener facturas por fecha: {ex.Message}");
                return new();
            }
        }

        public async Task<decimal> GetTotalVentasDelDiaAsync(DateTime fecha)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<dynamic>($"api/facturas/ventas-dia?fecha={fecha:yyyy-MM-dd}");
                return response?.total ?? 0m;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener total de ventas: {ex.Message}");
                return 0m;
            }
        }
    }
}