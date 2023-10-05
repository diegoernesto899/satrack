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
        public string? TituloTarea { get; set; }

        public string? descripcionTarea { get; set; }        

        public DateTime? fechaFinalizacion { get; set; }

        public int idCategoria { get; set; }
        
        public int idEstado { get; set; }
        
    }
}
