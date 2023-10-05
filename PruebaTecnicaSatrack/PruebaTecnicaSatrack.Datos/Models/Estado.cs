using System;
using System.Collections.Generic;

namespace PruebaTecnicaSatrack.Datos.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
