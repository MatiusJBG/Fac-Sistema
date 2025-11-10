using Application.DTOs;
using Application.Interfaces;
using System.Net.Http.Json;

namespace Cliente.Services
{
    public class ProductoHttpService : Application.Interfaces.IProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProductoDto>>("api/productos");
            return result ?? new List<ProductoDto>();
        }

        public async Task<IEnumerable<ProductoDto>> SearchByNameAsync(string nombre)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProductoDto>>($"api/productos/search?nombre={nombre}");
            return result ?? new List<ProductoDto>();
        }

        public async Task<IEnumerable<ProductoDto>> GetByTipoAsync(string tipo)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProductoDto>>($"api/productos/tipo/{tipo}");
            return result ?? new List<ProductoDto>();
        }

        public async Task<ProductoDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductoDto>($"api/productos/{id}");
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }

        public async Task<ProductoDto> CreateAsync(CreateProductoDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/productos", dto);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ProductoDto>();
            if (result == null)
                throw new Exception("No se pudo crear el producto");
            return result;
        }

        public async Task UpdateAsync(int id, UpdateProductoDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/productos/{id}", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/productos/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ProductoDto>> GetDisponiblesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProductoDto>>("api/productos/disponibles");
            return result ?? new List<ProductoDto>();
        }
    }
}