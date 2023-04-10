using System;
using System.Collections.Generic;

namespace SistemaVentaBlazor.Server.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
