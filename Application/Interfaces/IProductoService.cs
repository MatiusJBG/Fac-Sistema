using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> GetAllAsync();
        Task<ProductoDto?> GetByIdAsync(int id);
        Task<ProductoDto> CreateAsync(CreateProductoDto dto);
        Task UpdateAsync(int id, UpdateProductoDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductoDto>> GetDisponiblesAsync();
    }
}