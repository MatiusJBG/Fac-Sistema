using Core.Domain;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Cliente?> GetByCedulaAsync(string cedula)
        {
            return await _dbSet
                .Include(c => c.Facturas)
                .FirstOrDefaultAsync(c => c.Ced_Cli == cedula);
        }

        public async Task<Cliente?> GetByRucAsync(string ruc)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c => c.Ruc_Cli == ruc);
        }

        public async Task<IEnumerable<Cliente>> SearchByNameAsync(string nombre)
        {
            return await _dbSet
                .Where(c => c.Nom_Cli.Contains(nombre) || c.Ape_Cli.Contains(nombre))
                .ToListAsync();
        }
    }
}