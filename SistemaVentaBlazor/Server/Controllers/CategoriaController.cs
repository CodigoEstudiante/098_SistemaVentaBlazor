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
    public class CategoriaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<CategoriaDTO>> _response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                List<CategoriaDTO> _listaCategorias = new List<CategoriaDTO>();
                _listaCategorias = _mapper.Map<List<CategoriaDTO>>(await _categoriaRepositorio.Lista());

                if (_listaCategorias.Count > 0)
                    _response = new ResponseDTO<List<CategoriaDTO>>() { status = true, msg = "ok", value = _listaCategorias };
                else
                    _response = new ResponseDTO<List<CategoriaDTO>>() { status = false, msg = "sin resultados", value = null };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseDTO<List<CategoriaDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

    }
}
