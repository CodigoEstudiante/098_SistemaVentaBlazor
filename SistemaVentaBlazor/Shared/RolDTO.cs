using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentaBlazor.Shared
{
    public class RolDTO
    {
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }

        public override bool Equals(object o)
        {
            var other = o as RolDTO;
            return other?.IdRol == IdRol;
        }
        public override int GetHashCode() => IdRol.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
