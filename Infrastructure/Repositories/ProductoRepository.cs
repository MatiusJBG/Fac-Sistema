using Core.Domain;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Producto>> GetByTipoAsync(string tipo)
        {
            return await _dbSet
                .Where(p => p.Tip_Pro == tipo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Producto>> GetProductosDisponiblesAsync()
        {
            return await _dbSet
                .Where(p => p.Can_Pro > 0)
                .ToListAsync();
        }

        public async Task<Producto?> GetWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Actualizaciones)
                .Include(p => p.Entradas)
                .FirstOrDefaultAsync(p => p.Id_Pro == id);
        }
    }
}