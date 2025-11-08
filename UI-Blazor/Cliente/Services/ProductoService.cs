using Application.DTOs;
using System.Net.Http.Json;

namespace Cliente.Services
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductoDto>> GetAllAsync()
        {
            try
            {
                Console.WriteLine("🔍 Intentando obtener productos desde: api/productos");

                // Primero obtener la respuesta raw
                var response = await _httpClient.GetAsync("api/productos");
                Console.WriteLine($"📊 Status Code: {response.StatusCode}");

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"📄 Respuesta RAW: {content}");

                // Si empieza con '<', es HTML
                if (content.StartsWith("<"))
                {
                    Console.WriteLine("❌ La respuesta es HTML, no JSON!");
                    return new();
                }

                // Intentar deserializar
                var productos = System.Text.Json.JsonSerializer.Deserialize<List<ProductoDto>>(content, new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                Console.WriteLine($"✅ Productos deserializados: {productos?.Count ?? 0}");
                return productos ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en GetAllAsync: {ex.Message}");
                Console.WriteLine($"   Stack: {ex.StackTrace}");
                return new();
            }
        }

        public async Task<ProductoDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductoDto>($"api/productos/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener producto: {ex.Message}");
                return null;
            }
        }

        public async Task<ProductoDto> CreateAsync(CreateProductoDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/productos", dto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ProductoDto>() ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear producto: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAsync(int id, UpdateProductoDto dto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/productos/{id}", dto);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar producto: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/productos/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar producto: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ProductoDto>> SearchByNameAsync(string nombre)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ProductoDto>>($"api/productos/search?nombre={Uri.EscapeDataString(nombre)}") ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar productos: {ex.Message}");
                return new();
            }
        }

        public async Task<List<ProductoDto>> GetByTipoAsync(string tipo)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ProductoDto>>($"api/productos/tipo/{Uri.EscapeDataString(tipo)}") ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos por tipo: {ex.Message}");
                return new();
            }
        }
    }
}