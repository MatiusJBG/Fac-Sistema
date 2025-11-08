using Application.DTOs;

namespace Cliente.Services
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> GetAllAsync();
        Task<ProductoDto?> GetByIdAsync(int id);
        Task<ProductoDto> CreateAsync(CreateProductoDto dto);
        Task UpdateAsync(int id, UpdateProductoDto dto);
        Task DeleteAsync(int id);
        Task<List<ProductoDto>> SearchByNameAsync(string nombre);
        Task<List<ProductoDto>> GetByTipoAsync(string tipo);
    }
}