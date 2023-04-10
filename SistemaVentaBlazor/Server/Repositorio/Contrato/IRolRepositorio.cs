using SistemaVentaBlazor.Server.Models;

namespace SistemaVentaBlazor.Server.Repositorio.Contrato
{
    public interface IRolRepositorio
    {
        Task<List<Rol>> Lista();
    }
}
