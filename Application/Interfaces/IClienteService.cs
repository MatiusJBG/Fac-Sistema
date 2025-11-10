using Application.DTOs;

namespace Application.Interfaces
{
	public interface IClienteService
	{
		Task<IEnumerable<ClienteDto>> GetAllAsync();
		Task<ClienteDto?> GetByIdAsync(string cedula);
		Task<ClienteDto> CreateAsync(CreateClienteDto dto);
		Task UpdateAsync(string cedula, UpdateClienteDto dto);
		Task DeleteAsync(string cedula);
		Task<IEnumerable<ClienteDto>> SearchByNameAsync(string nombre);
	}
}