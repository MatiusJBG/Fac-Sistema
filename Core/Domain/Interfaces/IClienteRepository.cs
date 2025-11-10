using Core.Domain;

namespace Core.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente?> GetByCedulaAsync(string cedula);
        Task<Cliente?> GetByRucAsync(string ruc);
        Task<IEnumerable<Cliente>> SearchByNameAsync(string nombre);
    }
}