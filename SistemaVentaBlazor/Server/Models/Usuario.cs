using System;
using System.Collections.Generic;

namespace SistemaVentaBlazor.Server.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreApellidos { get; set; }

    public string? Correo { get; set; }

    public int? IdRol { get; set; }

    public string? Clave { get; set; }

    public bool? EsActivo { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
