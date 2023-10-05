using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSatrack.Negocio.Interfaces;
using PruebaTecnicaSatrack.Transversal.Objetos.ObjetosError;
using PruebaTecnicaSatrack.Transversal.Objetos.Tarea;

namespace PruebaTecnicaSatrack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TareaController : Controller
    {
        private readonly ILogger<TareaController> _logger;
        private readonly ITareasNegocio _tareasNegocio;
        
        public TareaController(ILogger<TareaController> logger, ITareasNegocio tareasNegocio)
        {
            _tareasNegocio = tareasNegocio;
            _logger = logger;
        }
        [HttpGet]        
        public async Task<IActionResult> ObtenerTareas()
        {
            try
            {
                var resultado = await _tareasNegocio.ObtenerTodasLasTareas();
                if (resultado.Any())
                {
                    return NotFound("No se encontraron tareas.");
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]        
        public async Task<IActionResult> AgregarTarea(TareaPeticion tarea) {
            try
            {
                await _tareasNegocio.AgregarTarea(tarea);

                return Ok("Tarea agregada correctamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem(
                    detail:ex.Message                    
                    );
            }
        }
       
    }
}
