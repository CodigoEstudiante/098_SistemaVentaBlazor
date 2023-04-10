using Microsoft.EntityFrameworkCore;
using SistemaVentaBlazor.Server.Models;
using SistemaVentaBlazor.Server.Repositorio.Contrato;

namespace SistemaVentaBlazor.Server.Repositorio.Implementacion
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public CategoriaRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Categoria>> Lista()
        {
            try
            {
                return await _dbContext.Categoria.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
