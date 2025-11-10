using Application.DTOs;
using System.Net.Http.Json;

namespace Cliente.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ClienteDto>> GetAllAsync()
        {
            try
            {
                Console.WriteLine("🔍 Intentando obtener clientes desde: api/clientes");

                var resultado = await _httpClient.GetFromJsonAsync<List<ClienteDto>>("api/clientes");

                if (resultado == null)
                {
                    Console.WriteLine("⚠️ Resultado NULL - retornando lista vacía");
                    return new();
                }

                Console.WriteLine($"✅ Clientes recibidos: {resultado.Count}");
                foreach (var cli in resultado)
                {
                    Console.WriteLine($"   - {cli.Nom_Cli} ({cli.Ced_Cli})");
                }

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en GetAllAsync: {ex.Message}");
                Console.WriteLine($"   Tipo: {ex.GetType().Name}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"   Inner: {ex.InnerException.Message}");
                }
                return new();
            }
        }

        public async Task<ClienteDto?> GetByIdAsync(string cedula)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ClienteDto>($"api/clientes/{cedula}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener cliente: {ex.Message}");
                return null;
            }
        }

        public async Task<ClienteDto> CreateAsync(CreateClienteDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/clientes", dto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ClienteDto>() ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cliente: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(string cedula, UpdateClienteDto dto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/clientes/{cedula}", dto);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar cliente: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(string cedula)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/clientes/{cedula}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ClienteDto>> SearchByNameAsync(string nombre)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ClienteDto>>($"api/clientes/search?nombre={Uri.EscapeDataString(nombre)}") ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar clientes: {ex.Message}");
                return new();
            }
        }
    }
}