using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSatrack.Negocio.Implementacion;
using PruebaTecnicaSatrack.Negocio.Interfaces;

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
        [HttpGet("ObtenerTareas")]
        public async Task<IActionResult> ObtenerTareas()
        {
            try
            {
                var resultado = await _tareasNegocio.ObtenerTodasLasTareas();
                if (!resultado.Any())
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
        [HttpPost("AgregarTarea")]
        public async Task<IActionResult> AgregarTarea(TareaPeticion tarea)
        {
            try
            {
                await _tareasNegocio.AgregarTarea(tarea);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem(
                    detail: ex.Message
                    );
            }
        }

        [HttpPut("ActualizarTarea")]
        public async Task<IActionResult> ActualizarTarea(TareaPeticion tarea)
        {
            try
            {
                if (!await _tareasNegocio.ActualizarTarea(tarea))
                {
                    return NotFound(string.Format("La tarea {0} no existe", tarea.TituloTarea));
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem(
                    detail: ex.Message
                    );
            }
        }
        [HttpDelete("EliminarTarea/{idTarea}")]
        public async Task<IActionResult> EliminarTarea(int idTarea)
        {
            if (idTarea == 0)
                return BadRequest("idTarea es requerido");
            try
            {
                if (!await _tareasNegocio.EliminarTarea(idTarea))
                {
                    return NotFound(string.Format("No existe la tarea."));
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem(
                    detail: ex.Message
                    );
            }
        }


        [HttpGet("ObtenerEstados")]
        public async Task<IActionResult> ObtenerEstadosTarea()
        {
            try
            {
                var resultado = await _tareasNegocio.ObtenerEstados();
                if (!resultado.Any())
                {
                    return NotFound("No se encontraron estados.");
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }



    }
}
