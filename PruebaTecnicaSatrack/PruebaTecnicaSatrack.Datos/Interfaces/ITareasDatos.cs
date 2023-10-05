using PruebaTecnicaSatrack.Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSatrack.Datos.Interfaces
{
    public interface ITareasDatos
    {
        Task<bool> AgregarTarea(Tarea tarea);
        Task<IEnumerable<Tarea>> ObtenerTodasLasTareas();
        Task<Tarea> ObtenerTareaPorId(int idTarea);
        Task<bool> ActualizarTarea(Tarea tarea);
        bool EliminarTarea(int idTarea);
        Task<List<Estado>> ObtenerEstados();
    }
}
