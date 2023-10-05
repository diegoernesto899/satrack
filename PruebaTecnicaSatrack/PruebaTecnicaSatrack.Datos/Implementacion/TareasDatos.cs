using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSatrack.Datos.Interfaces;
using PruebaTecnicaSatrack.Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSatrack.Datos.Implementacion
{
    public class TareasDatos : ITareasDatos
    {
        private SatrackContext _context;
        public TareasDatos(SatrackContext context)
        {
            _context = context;
        }

        public async Task<bool> AgregarTarea(Tarea tarea)
        {
            try
            {
                _context.Add(tarea);
                await _context.SaveChangesAsync();
                return true;
                //return _context.Tareas.Single(l => (l.TituloTarea == tarea.TituloTarea) && (l.FechaCreacion == tarea.FechaCreacion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ActualizarTarea(Tarea tarea)
        {
            try
            {
                _context.Update(tarea);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EliminarTarea(int idTarea)
        {
            bool response = false;
            try
            {
                _context.Remove(idTarea);
                await _context.SaveChangesAsync();
                response = true;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tarea> ObtenerTareaPorId(int idTarea)
        {
            try
            {
                var tareaEncontrada = await _context.Tareas.FirstOrDefaultAsync(x => x.IdTarea == idTarea);
                return tareaEncontrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Tarea>> ObtenerTodasLasTareas()
        {
            try
            {
                return await _context.Tareas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
