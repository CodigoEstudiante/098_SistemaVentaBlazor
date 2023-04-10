using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVentaBlazor.Server.Repositorio.Contrato;
using SistemaVentaBlazor.Shared;

namespace SistemaVentaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDashBoardRepositorio _dashboardRepositorio;
        public DashBoardController(IDashBoardRepositorio dashboardRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _dashboardRepositorio = dashboardRepositorio;
        }

        [HttpGet]
        [Route("Resumen")]
        public async Task<IActionResult> Resumen()
        {
            ResponseDTO<DashBoardDTO> _response = new ResponseDTO <DashBoardDTO>();

            try
            {

                DashBoardDTO vmDashboard = new DashBoardDTO();

                vmDashboard.TotalVentas = await _dashboardRepositorio.TotalVentasUltimaSemana();
                vmDashboard.TotalIngresos = await _dashboardRepositorio.TotalIngresosUltimaSemana();
                vmDashboard.TotalProductos = await _dashboardRepositorio.TotalProductos();

                List<VentaSemanaDTO> listaVentasSemana = new List<VentaSemanaDTO>();

                foreach (KeyValuePair<string, int> item in await _dashboardRepositorio.VentasUltimaSemana())
                {
                    listaVentasSemana.Add(new VentaSemanaDTO()
                    {
                        Fecha = item.Key,
                        Total = item.Value
                    });
                }
                vmDashboard.VentasUltimaSemana = listaVentasSemana;

                _response = new ResponseDTO<DashBoardDTO>() { status = true, msg = "ok", value = vmDashboard };
                return StatusCode(StatusCodes.Status200OK, _response);

            }
            catch (Exception ex)
            {
                _response = new ResponseDTO<DashBoardDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }
    }
}
