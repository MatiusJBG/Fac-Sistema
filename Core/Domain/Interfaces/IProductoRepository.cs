using Core.Domain;

namespace Core.Interfaces
{
    public interface IProductoRepository : IRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetByTipoAsync(string tipo);
        Task<IEnumerable<Producto>> GetProductosDisponiblesAsync();
        Task<Producto?> GetWithDetailsAsync(int id);
    }
}