using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PruebaTecnicaSatrack.Transversal.DTOs;
using System.Globalization;
using PruebaTecnicaSatrack.Datos.Models;
using PruebaTecnicaSatrack.Transversal.Objetos.Tarea;

namespace PruebaTecnicaSatrack.Transversal.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            #region Tarea

            CreateMap<Tarea, TareaDTO>().ReverseMap();

            CreateMap<TareaPeticion, Tarea>()
                .ForMember(destino => destino.TituloTarea, opt => opt.MapFrom(origen => origen.Titulo))
                .ForMember(destino => destino.EstadoTarea, opt => opt.MapFrom(origen => origen.Estado))
                .ForMember(destino => destino.CategoriaTarea, opt => opt.MapFrom(origen => origen.Categoria))
                .ForMember(destino => destino.DescripcionTarea, opt => opt.MapFrom(origen => origen.Descripcion))                
                ;
            #endregion

            #region Categoria

            CreateMap<Categoria, CategoriaDTO>()
                .ForMember(destino => destino.Id, opt => opt.MapFrom(origen => origen.IdCategoria))
                .ForMember(destino => destino.Nombre, opt => opt.MapFrom(origen => origen.NombreCategoria))
                ;

            CreateMap<CategoriaDTO, Categoria>()
                .ForMember(destino => destino.IdCategoria, opt => opt.MapFrom(origen => origen.Id))
                .ForMember(destino => destino.NombreCategoria, opt => opt.MapFrom(origen => origen.Nombre))
                ;

            #endregion

        }
    }
}
