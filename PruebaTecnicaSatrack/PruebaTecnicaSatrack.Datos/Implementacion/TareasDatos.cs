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

        public bool EliminarTarea(int idTarea)
        {
            bool response = false;
            try
            {
                var tarea = new Tarea { IdTarea = idTarea };
                _context.Remove(tarea);
                _context.SaveChangesAsync();
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
                return await _context.Tareas.Include(c=>c.CategoriaTareaNavigation).Include(e=>e.EstadoTareaNavigation).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Estado>> ObtenerEstados()
        {
            return _context.Estados.ToListAsync();
        }
    }
}
