using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSatrack.Negocio.Interfaces;

namespace PruebaTecnicaSatrack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ILogger<TareaController> _logger;
        private readonly ICategoriaNegocio _categoriaNegocio;

        public CategoriaController(ILogger<TareaController> logger , ICategoriaNegocio categoriaNegocio) 
        { 
            _categoriaNegocio = categoriaNegocio;
            _logger = logger;
        }

        // GET: CategoriaController/ObtenerCategorias
        [HttpGet("ObtenerCategorias")]
        public async Task<IActionResult> ObtenerCategorias()
        {
            try
            {
                var resultado = await _categoriaNegocio.ObtenerCategorias();
                if (!resultado.Any())
                {
                    return NotFound("No se encontraron categorias.");
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
