using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentaBlazor.Shared
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string? NombreApellidos { get; set; }
        public string? Correo { get; set; }
        public int IdRol { get; set; }
        public string? rolDescripcion { get; set; }
        public string? Clave { get; set; }
    }
}
