
namespace SistemaVentaBlazor.Client.Servicios.Contrato
{
    public interface ICategoriaService
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista();
    }
}
