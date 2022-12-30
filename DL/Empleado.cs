using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace DL;

public partial class Empleado
{
    public int? IdEmpleado { get; set; }

    public string? NumeroNomina { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public int? IdEstado { get; set; }

    public string? NombreEstado { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }
}
