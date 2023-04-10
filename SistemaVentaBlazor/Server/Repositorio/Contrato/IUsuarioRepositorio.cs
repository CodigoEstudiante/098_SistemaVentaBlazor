using SistemaVentaBlazor.Server.Models;
using System.Linq.Expressions;

namespace SistemaVentaBlazor.Server.Repositorio.Contrato
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> Lista();
        Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null);
        Task<Usuario> Crear(Usuario entidad);
        Task<bool> Editar(Usuario entidad);
        Task<bool> Eliminar(Usuario entidad);
        Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null);
    }
}
