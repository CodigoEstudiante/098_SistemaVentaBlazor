using SistemaVentaBlazor.Client.Servicios.Contrato;
using SistemaVentaBlazor.Shared;
using System.Net.Http.Json;

namespace SistemaVentaBlazor.Client.Servicios.Implementacion
{
    public class CategoriaService : ICategoriaService
    {
     
        private readonly HttpClient _http;
        public CategoriaService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>("api/categoria/Lista");
            return result;
        }
    }
}
