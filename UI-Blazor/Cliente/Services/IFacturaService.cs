using Application.DTOs;

namespace Cliente.Services
{
    public interface IFacturaService
    {
        Task<List<FacturaDto>> GetAllAsync();
        Task<FacturaDto?> GetByIdAsync(int id);
        Task<FacturaDto> CreateAsync(CreateFacturaDto dto);
        Task<List<FacturaDto>> GetByClienteAsync(string cedula);
        Task<List<FacturaDto>> GetByFechaRangoAsync(DateTime desde, DateTime hasta);
        Task<decimal> GetTotalVentasDelDiaAsync(DateTime fecha);
    }
}