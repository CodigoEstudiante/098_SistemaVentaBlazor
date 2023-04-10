using SistemaVentaBlazor.Server.Models;

namespace SistemaVentaBlazor.Server.Repositorio.Contrato
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Lista();
    }
}
