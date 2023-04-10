using SistemaVentaBlazor.Client.Utilidades;

namespace SistemaVentaBlazor.Client.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Lista();
        Task<ResponseDTO<UsuarioDTO>> IniciarSesion(UsuarioLogin request);
        Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO entidad);
        Task<bool> Editar(UsuarioDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
