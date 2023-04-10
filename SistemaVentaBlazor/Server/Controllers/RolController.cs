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
    public class RolController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRolRepositorio _rolRepositorio;
        public RolController(IRolRepositorio rolRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _rolRepositorio = rolRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<RolDTO>> _ResponseDTO = new ResponseDTO<List<RolDTO>>();

            try
            {
                List<RolDTO> _listaRoles = new List<RolDTO>();
                _listaRoles = _mapper.Map<List<RolDTO>>(await _rolRepositorio.Lista());

                if (_listaRoles.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<RolDTO>>() { status = true, msg = "ok", value = _listaRoles };
                else
                    _ResponseDTO = new ResponseDTO<List<RolDTO>>() { status = false, msg = "sin resultados", value = null };


                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<RolDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
    }
}
