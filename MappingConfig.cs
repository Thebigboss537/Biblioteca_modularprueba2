using AutoMapper;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AutorDto, Autor>();
                config.CreateMap<Autor, AutorDto>();

                config.CreateMap<DevolucionDto, Devolucion>();
                config.CreateMap<Devolucion, DevolucionDto>();

                config.CreateMap<PrestamoDto, Prestamo>();
                config.CreateMap<Prestamo, PrestamoDto>();

                config.CreateMap<Programa_academicoDto, Programa_academico>();
                config.CreateMap<Programa_academico, Programa_academicoDto>();

                config.CreateMap<ReservaDto, Reserva>();
                config.CreateMap<Reserva, ReservaDto>();

                config.CreateMap<RolDto, Rol>();
                config.CreateMap<Rol, RolDto>();

                config.CreateMap<Tipo_materialDto, Tipo_material>();
                config.CreateMap<Tipo_material, Tipo_materialDto>();

                /*config.CreateMap<UsuarioDto, Usuario>();
                config.CreateMap<Usuario, UsuarioDto>();*/

                config.CreateMap<EditorialDto, Editorial>();
                config.CreateMap<Editorial, EditorialDto>();

                config.CreateMap<SedeDto, Sede>();
                config.CreateMap<Sede, SedeDto>();

                config.CreateMap<CategoriaDto, Categoria>();
                config.CreateMap<Categoria, CategoriaDto>();

                config.CreateMap<Material_autorDto, Material_autor>();
                config.CreateMap<Material_autor, Material_autorDto>();

                config.CreateMap<Material_categoriaDto, Material_categoria>();
                config.CreateMap<Material_categoria, Material_categoriaDto>();

                config.CreateMap<UsuarioDto, Usuario>();
                config.CreateMap<Usuario, UsuarioDto>();

                config.CreateMap<MaterialDto, Material>().ForMember(m => m.Archivo, options => options.Ignore());
                config.CreateMap<Material, MaterialDto>().ForMember(m => m.Archivo, options => options.Ignore());


            });
            
            return mappingConfig;
        }
         
    }
}
