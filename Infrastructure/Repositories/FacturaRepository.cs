using Core.Domain;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        public FacturaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Factura>> GetByClienteAsync(string cedula)
        {
            return await _dbSet
                .Include(f => f.Detalles)
                .Where(f => f.Ced_Cli_Per == cedula)
                .OrderByDescending(f => f.Fec_Fac)
                .ToListAsync();
        }

        public async Task<Factura?> GetWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(f => f.Cliente)
                .Include(f => f.Detalles)
                    .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(f => f.Id_Fac == id);
        }

        public async Task<IEnumerable<Factura>> GetByFechaRangoAsync(DateTime inicio, DateTime fin)
        {
            return await _dbSet
                .Where(f => f.Fec_Fac >= inicio && f.Fec_Fac <= fin)
                .OrderByDescending(f => f.Fec_Fac)
                .ToListAsync();
        }
    }
}