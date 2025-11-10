using Core.Domain;

namespace Core.Interfaces
{
    public interface IFacturaRepository : IRepository<Factura>
    {
        Task<IEnumerable<Factura>> GetByClienteAsync(string cedula);
        Task<Factura?> GetWithDetailsAsync(int id);
        Task<IEnumerable<Factura>> GetByFechaRangoAsync(DateTime inicio, DateTime fin);
    }
}