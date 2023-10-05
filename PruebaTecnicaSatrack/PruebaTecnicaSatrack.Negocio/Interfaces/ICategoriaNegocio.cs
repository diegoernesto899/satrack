using PruebaTecnicaSatrack.Transversal.DTOs;
using PruebaTecnicaSatrack.Transversal.Objetos.Tarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSatrack.Negocio.Interfaces
{
    public interface ICategoriaNegocio
    {
        Task<List<CategoriaDTO>> ObtenerCategorias(); 
        
        
        
        
    }
}
