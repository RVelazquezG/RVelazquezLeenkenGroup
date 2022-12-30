using System;
using System.Collections.Generic;

namespace DL;

public partial class Estado
{
    public int? IdEstado { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
