using Microsoft.EntityFrameworkCore;
using SistemaVentaBlazor.Server.Models;
using SistemaVentaBlazor.Server.Repositorio.Contrato;

namespace SistemaVentaBlazor.Server.Repositorio.Implementacion
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public RolRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Rol>> Lista()
        {
            try
            {
                return await _dbContext.Rols.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
