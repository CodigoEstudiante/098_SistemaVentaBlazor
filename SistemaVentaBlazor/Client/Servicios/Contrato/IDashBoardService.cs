namespace SistemaVentaBlazor.Client.Servicios.Contrato
{
    public interface IDashBoardService
    {
        Task<ResponseDTO<DashBoardDTO>> Resumen();
    }
}
