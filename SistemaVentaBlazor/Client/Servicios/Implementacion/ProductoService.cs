
using System.Net.Http.Json;

namespace SistemaVentaBlazor.Client.Servicios.Implementacion
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _http;
        public ProductoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/producto/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();
            return response!;
        }

        public async Task<bool> Editar(ProductoDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/producto/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/producto/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>("api/producto/Lista");
            return result!;
        }
    }
}
