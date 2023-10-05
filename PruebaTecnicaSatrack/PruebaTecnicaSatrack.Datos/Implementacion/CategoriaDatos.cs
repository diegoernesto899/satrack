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
    public class CategoriaDatos : ICategoriaDatos
    {
        private SatrackContext _context;

        public CategoriaDatos(SatrackContext context) 
        {
        _context = context;
        }
        public Task<List<Categoria>> ObtenerCategorias()
        {
            return _context.Categoria.ToListAsync();
        }
    }
}
