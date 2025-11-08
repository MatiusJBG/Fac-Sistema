using Application.DTOs;

namespace Cliente.Services
{
    public interface IClienteService
    {
        Task<List<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(string cedula);
        Task<ClienteDto> CreateAsync(CreateClienteDto dto);
        Task UpdateAsync(string cedula, UpdateClienteDto dto);
        Task DeleteAsync(string cedula);
        Task<List<ClienteDto>> SearchByNameAsync(string nombre);
    }
}