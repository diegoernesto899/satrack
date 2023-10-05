using PruebaTecnicaSatrack.Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSatrack.Transversal.Objetos.Tarea
{
    public class TareaPeticion
    {

        public int IdTarea { get; set; }
        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }        

        public DateTime? FechaFinalizacion { get; set; }

        public int Categoria { get; set; }
        public int Estado { get; set; }
        
    }
}
