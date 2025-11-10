using Application.DTOs;

namespace Application.Interfaces
{
    public interface IFacturaService
    {
        Task<IEnumerable<FacturaDto>> GetAllAsync();
        Task<FacturaDto?> GetByIdAsync(int id);
        Task<FacturaDto> CreateAsync(CreateFacturaDto dto);
        Task<IEnumerable<FacturaDto>> GetByClienteAsync(string cedula);
    }
}