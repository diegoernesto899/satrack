using AutoMapper;
using PruebaTecnicaSatrack.Datos.Interfaces;
using PruebaTecnicaSatrack.Datos.Models;
using PruebaTecnicaSatrack.Negocio.Interfaces;
using PruebaTecnicaSatrack.Transversal.DTOs;
using PruebaTecnicaSatrack.Transversal.Objetos.Tarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnicaSatrack.Negocio.Implementacion
{
    public class TareasNegocio : ITareasNegocio
    {
        private readonly ITareasDatos _datos;
        private readonly IMapper _mapper;
        public TareasNegocio(ITareasDatos datos, IMapper mapper)
        {
            _datos = datos;
            _mapper = mapper;
        }

        public async Task<bool> AgregarTarea(TareaPeticion tarea)
        {
            var tareaDatos = _mapper.Map<Tarea>(tarea);
            tareaDatos.FechaCreacion = DateTime.Now;

            return await _datos.AgregarTarea(tareaDatos); 
        }

        public async Task<bool> ActualizarTarea(TareaPeticion tarea)
        {
            var existeTarea = _datos.ObtenerTareaPorId(tarea.IdTarea);

            if (existeTarea == null)
            {
                return false;
            }
            var tareaDatos = _mapper.Map<Tarea>(tarea);
            tareaDatos.FechaCreacion = DateTime.Now;

            return await _datos.ActualizarTarea(tareaDatos);
        }

        public async Task<bool> EliminarTarea(int idTarea)
        {
            var existeTarea = _datos.ObtenerTareaPorId(idTarea);

            if (existeTarea == null)
            {
                return false;
            }
            else
            {
                await _datos.EliminarTarea(idTarea);
                return true;
            }
        }

        public async Task<TareaDTO> ObtenerTareaPorId(int idTarea)
        {
            //return await _datos.ObtenerTareaPorId(idTarea);
            return null;
        }

        public async Task<IEnumerable<TareaDTO>> ObtenerTodasLasTareas()
        {
            //return await _datos.ObtenerTodasLasTareas();
            return null;
        }
    }
}
