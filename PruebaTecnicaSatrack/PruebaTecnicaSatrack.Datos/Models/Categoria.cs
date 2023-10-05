using System;
using System.Collections.Generic;

namespace PruebaTecnicaSatrack.Datos.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? NombreCategoria { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
