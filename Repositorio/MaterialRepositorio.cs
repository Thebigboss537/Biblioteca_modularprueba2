using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca_modular.Repositorio
{
    public class MaterialRepositorio : IMaterialRepositorio
    {

        private readonly DataContext _db;
        private IMapper _mapper;
        
        public MaterialRepositorio(DataContext db, IMapper mapper)
        {
            
            _db = db;
            _mapper = mapper;
        }
        public async Task<MaterialDto> AgregarArchivo(Material_archivoDto Material_ArchivoDto)
        {
            var a = await _db.Materiales.FindAsync(Material_ArchivoDto.Id_material);
            a.Archivo = Material_ArchivoDto.Ruta;
            _db.Materiales.Update(a);
            await _db.SaveChangesAsync();
            return _mapper.Map<Material, MaterialDto>(a);
        }

        public async Task<MaterialDto> CreateUpdate(MaterialDto MaterialDto)
        {
            Material Material = _mapper.Map<MaterialDto, Material>(MaterialDto);
            if (Material.Id_material > 0)
            {
                _db.Materiales.Update(Material);
            }
            else
            {
                /*if(MaterialDto.Ruta != null)
                {
                    Material.Archivo = MaterialDto.Ruta;
                }*/
                await _db.Materiales.AddAsync(Material);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Material, MaterialDto>(Material);
        }

        public async Task<bool> DeleteMaterial(int id)
        {
            try
            {
                Material Material = await _db.Materiales.FindAsync(id);
                if (Material == null)
                {
                    return false;
                }
                _db.Materiales.Remove(Material);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<MaterialDto> GetMaterialById(int id)
        {
            MaterialDto Material = _mapper.Map<MaterialDto>(await _db.Materiales.Include(e => e.Editorial).Include(e => e.Sede).Include(e => e.Tipo_material).Where(x => x.Id_material == id).FirstOrDefaultAsync());


            Material.Autores = _mapper.Map<List<Autor>, List<AutorDto>>(await _db.Material_Autores.Where(e => e.Id_material == Material.Id_material).Select(e => e.Autor).ToListAsync());

            Material.Categorias = _mapper.Map<List<Categoria>, List<CategoriaDto>>(await _db.Material_Categorias.Where(e => e.Id_material == Material.Id_material).Select(e => e.Categoria).ToListAsync());

            foreach (var b in Material.Autores)
            {
                Material.nombresdeautores = b.Nombre.ToString() + " " + Material.nombresdeautores;
            }

            foreach (var c in Material.Categorias)
            {
                Material.nombresdecategorias = c.Nombre.ToString() + " " + Material.nombresdecategorias;
            }


            //a.Ruta = Material.Archivo;

            return Material;
        }

        public async Task<List<MaterialDto>> GetMateriales()
        {

            /*List<Material_autor> material = await _db.Materiales.Join(_db.Material_Autores, x => x.Id_material, y => y.Id_material, (x, y) => new { Materiales = x, Material_Autores = y }).Select(e => e.Material_Autores).Include(e => e.Material).Include(e => e.Autor).Include(e => e.Material.Editorial).Include(e => e.Material.Sede).Include(e => e.Material.Tipo_material).ToListAsync();*/

            /*var a = await _db.Material_Autores.Include(e => e.Material).Include(e => e.Autor).Join(_db.Material_Categorias, x => x.Id_material, y => y.Id_material, (x, y) => new { Material_Autores = x, Material_Categorias = y }).ToListAsync();*/

            List<MaterialDto> materials = _mapper.Map <List<MaterialDto>>(await _db.Materiales.Include(e => e.Editorial).Include(e => e.Sede).Include(e => e.Tipo_material).ToListAsync());   /* AddRange(_db.Material_Autores.Where(e => e.Id_material == 1).Select(e => e.Autor).;*/

            

            foreach (var a in materials)
            {
                a.Autores = _mapper.Map<List<Autor>, List<AutorDto>>(await _db.Material_Autores.Where(e => e.Id_material == a.Id_material).Select(e => e.Autor).ToListAsync()); 

                a.Categorias = _mapper.Map<List<Categoria>, List<CategoriaDto>>(await _db.Material_Categorias.Where(e => e.Id_material == a.Id_material).Select(e => e.Categoria).ToListAsync());

                foreach (var b in a.Autores)
                {
                    a.nombresdeautores = b.Nombre.ToString() + " " + a.nombresdeautores;
                }

                foreach (var c in a.Categorias)
                {
                    a.nombresdecategorias = c.Nombre.ToString() + " " + a.nombresdecategorias;
                }
                /*a.Autores = await _db.Material_Autores.Where(e => e.Id_material == a.Id_material).Select(e => e.Autor).ToListAsync();*/
                
            }


            /*var a = await _db.Autores.Join(_db.Material_Autores, x => x.Id_autor, y => y.Id_autor, (x, y) => new { Autores = x, Material_Autores = y }).Join(_db.Materiales, x => x.Material_Autores.Id_material, y => y.Id_material, (x, y) => new { Material_Autores = x, Materiales = y }).ToListAsync(); /*.Join(_db.Material_Categorias, x => x.Id_material, y => y.Id_material, (x, y) => new { Materiales = x, Material_Categorias = y }).Join(_db.Categorias, x => x.Material_Categorias.Id_categoria, y => y.Id_categoria, (x, y) => new { Material_Categorias = x, Categorias = y }).ToListAsync();*/

            /*var d = await _db.Materiales.Join(_db.Material_Autores, x => x.Id_material, y => y.Id_material, (x, y) => new { Materiales = x, Material_Autores = y }).Select(e => e.Material_Autores).Include(e => e.Autor).Include(e => e.Material).Include(e => e.Material.Editorial).Include(e => e.Material.Sede).Include(e => e.Material.Tipo_material).ToListAsync();   /*.Join(_db.Material_Categorias, x => x.Materiales.Id_material, y => y.Id_material, (x, y) => new { Materiales = x, Material_Categorias = y }).ToListAsync();*/

            /*.Select(e => e.Materiales).Include(e => e.Material_Autores).Include(e => e.Materiales.Editorial).Include(e => e.Materiales.Sede).ToListAsync();*/

            return materials;
        }

        
    }
}
