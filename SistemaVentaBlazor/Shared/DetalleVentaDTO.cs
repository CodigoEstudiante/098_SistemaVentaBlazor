using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentaBlazor.Shared
{
    public class DetalleVentaDTO
    {
        public int IdProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio{ get; set; }
        public decimal? Total{ get; set; }
    }
}
