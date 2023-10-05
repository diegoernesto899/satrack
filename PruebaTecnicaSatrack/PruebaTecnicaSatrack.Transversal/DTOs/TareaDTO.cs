using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSatrack.Transversal.DTOs
{
    public class TareaDTO
    {
        public int IdTarea { get; set; }
        public string? TituloTarea { get; set; }
        public string? DescripcionTarea { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public int? EstadoTarea { get; set; }
    }
}
