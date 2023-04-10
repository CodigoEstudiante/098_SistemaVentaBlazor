using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVentaBlazor.Server.Models;
using SistemaVentaBlazor.Server.Repositorio.Contrato;
using SistemaVentaBlazor.Shared;
using System.Globalization;

namespace SistemaVentaBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVentaRepositorio _ventaRepositorio;

        public VentaController(IVentaRepositorio ventaRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _ventaRepositorio = ventaRepositorio;
        }


        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO request)
        {
            ResponseDTO<VentaDTO> _ResponseDTO = new ResponseDTO<VentaDTO>();
            try
            {

                Venta venta_creada = await _ventaRepositorio.Registrar(_mapper.Map<Venta>(request));
                request = _mapper.Map<VentaDTO>(venta_creada);

                if (venta_creada.IdVenta != 0)
                    _ResponseDTO = new ResponseDTO<VentaDTO>() { status = true, msg = "ok", value = request };
                else
                    _ResponseDTO = new ResponseDTO<VentaDTO>() { status = false, msg = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<VentaDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaInicio, string? fechaFin)
        {
            ResponseDTO<List<VentaDTO>> _ResponseDTO = new ResponseDTO<List<VentaDTO>>();

            numeroVenta = numeroVenta is null ? "" : numeroVenta;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaInicio is null ? "" : fechaFin;

            try
            {

                List<VentaDTO> vmHistorialVenta = _mapper.Map<List<VentaDTO>>(await _ventaRepositorio.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin));

                if (vmHistorialVenta.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<VentaDTO>>() { status = true, msg = "ok", value = vmHistorialVenta };
                else
                    _ResponseDTO = new ResponseDTO<List<VentaDTO>>() { status = false, msg = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<VentaDTO>>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);

            }

        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            ResponseDTO<List<ReporteDTO>> _ResponseDTO = new ResponseDTO<List<ReporteDTO>>();
            try
            {

                List<ReporteDTO> listaReporte = _mapper.Map<List<ReporteDTO>>(await _ventaRepositorio.Reporte(fechaInicio, fechaFin));

                if (listaReporte.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ReporteDTO>>() { status = true, msg = "ok", value = listaReporte };
                else
                    _ResponseDTO = new ResponseDTO<List<ReporteDTO>>() { status = false, msg = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ReporteDTO>>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);

            }

        }
    }
}
