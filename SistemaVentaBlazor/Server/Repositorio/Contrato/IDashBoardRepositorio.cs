namespace SistemaVentaBlazor.Server.Repositorio.Contrato
{
    public interface IDashBoardRepositorio
    {
        Task<int> TotalVentasUltimaSemana();
        Task<string> TotalIngresosUltimaSemana();
        Task<int> TotalProductos();
        Task<Dictionary<string, int>> VentasUltimaSemana();
    }
}
