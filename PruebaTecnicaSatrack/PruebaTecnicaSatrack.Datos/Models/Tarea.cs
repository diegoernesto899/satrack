using System;
using System.Collections.Generic;

namespace PruebaTecnicaSatrack.Datos.Models;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string TituloTarea { get; set; } = null!;

    public string? DescripcionTarea { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaFinalizacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? CategoriaTarea { get; set; }

    public int? EstadoTarea { get; set; }

    public virtual Categoria? CategoriaTareaNavigation { get; set; }

    public virtual Estado? EstadoTareaNavigation { get; set; }
}
