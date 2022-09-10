using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class Material_categoriaRepositorio : IMaterial_categoriaRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;
        public Material_categoriaRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Material_categoriaDto> CreateUpdate(Material_categoriaDto material_categoriaDto)
        {
            Material_categoria material_categoria = _mapper.Map<Material_categoriaDto, Material_categoria>(material_categoriaDto);
            if (material_categoria.Id > 0)
            {
                _db.Material_Categorias.Update(material_categoria);
            }
            else
            {
                await _db.Material_Categorias.AddAsync(material_categoria);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Material_categoria, Material_categoriaDto>(material_categoria);
        }

        public async Task<bool> DeleteMaterial_categoria(int id)
        {
            try
            {
                Material_categoria material_categoria = await _db.Material_Categorias.FindAsync(id);
                if (material_categoria == null)
                {
                    return false;
                }
                _db.Material_Categorias.Remove(material_categoria);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Material_categoriaDto> GetMaterial_categoriaById(int id)
        {
            Material_categoria material_categoria = await _db.Material_Categorias.FindAsync(id);

            return _mapper.Map<Material_categoriaDto>(material_categoria);
        }

        public async Task<List<Material_categoriaDto>> GetMaterial_categorias()
        {
            List<Material_categoria> lista = await _db.Material_Categorias.ToListAsync();

            return _mapper.Map<List<Material_categoriaDto>>(lista);
        }
    }
}
