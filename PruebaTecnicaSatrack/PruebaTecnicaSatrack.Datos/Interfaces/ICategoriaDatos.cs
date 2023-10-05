using PruebaTecnicaSatrack.Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSatrack.Datos.Interfaces
{
    public interface ICategoriaDatos
    {
        Task<List<Categoria>> ObtenerCategorias();
    }
}
