using AutoMapper;
using PruebaTecnicaSatrack.Datos.Interfaces;
using PruebaTecnicaSatrack.Negocio.Interfaces;
using PruebaTecnicaSatrack.Transversal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSatrack.Negocio.Implementacion
{
    public class CategoriaNegocio : ICategoriaNegocio
    {
        private readonly ICategoriaDatos _categoriaDatos;
        private readonly IMapper _mapper;
        public CategoriaNegocio(ICategoriaDatos categoriaDatos, IMapper mapper) 
        {
            _categoriaDatos = categoriaDatos;
            _mapper = mapper;
        }

        public async Task<List<CategoriaDTO>> ObtenerCategorias() 
        {
            var listaCategorias = await _categoriaDatos.ObtenerCategorias();
            var respuestaListaCategorias = _mapper.Map<List<CategoriaDTO>>(listaCategorias);
            return respuestaListaCategorias;
        }
    }
}
