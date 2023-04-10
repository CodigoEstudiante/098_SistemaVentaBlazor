using Microsoft.EntityFrameworkCore;
using SistemaVentaBlazor.Server.Models;
using SistemaVentaBlazor.Server.Repositorio.Contrato;
using System.Linq.Expressions;

namespace SistemaVentaBlazor.Server.Repositorio.Implementacion
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DbventaBlazorContext _dbContext;

        public UsuarioRepositorio(DbventaBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null)
        {
            IQueryable<Usuario> queryEntidad = filtro == null ? _dbContext.Usuarios : _dbContext.Usuarios.Where(filtro);
            return queryEntidad;
        }

        public async Task<Usuario> Crear(Usuario entidad)
        {
            try
            {
                _dbContext.Set<Usuario>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Usuario entidad)
        {
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Usuario entidad)
        {
            try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Usuario>> Lista()
        {
            try
            {
                return await _dbContext.Usuarios.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Usuarios.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
