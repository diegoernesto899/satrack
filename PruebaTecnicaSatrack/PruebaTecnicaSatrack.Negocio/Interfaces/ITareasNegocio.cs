using PruebaTecnicaSatrack.Datos.Models;
using PruebaTecnicaSatrack.Transversal.DTOs;
using PruebaTecnicaSatrack.Transversal.Objetos.Tarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSatrack.Negocio.Interfaces
{
    public interface ITareasNegocio
    {
        string ValidarObjeto(TareaPeticion tarea);
        Task<bool> AgregarTarea(TareaPeticion tarea);
        Task<IEnumerable<TareaDTO>> ObtenerTodasLasTareas();
        Task<TareaDTO> ObtenerTareaPorId(int idTarea);
        Task<bool> ActualizarTarea(TareaPeticion tarea);
        Task<bool> EliminarTarea(int idTarea);
        Task<List<EstadoDTO>> ObtenerEstados();
    }
}
