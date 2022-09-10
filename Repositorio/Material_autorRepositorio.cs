using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class Material_autorRepositorio : IMaterial_autorRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;
        public Material_autorRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Material_autorDto> CreateUpdate(Material_autorDto material_autorDto)
        {
            Material_autor material_autor = _mapper.Map<Material_autorDto, Material_autor>(material_autorDto);
            if (material_autor.Id > 0)
            {
                _db.Material_Autores.Update(material_autor);
            }
            else
            {
                await _db.Material_Autores.AddAsync(material_autor);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Material_autor, Material_autorDto>(material_autor);
        }

        public async Task<bool> DeleteMaterial_autor(int id)
        {
            try
            {
                Material_autor material_autor = await _db.Material_Autores.FindAsync(id);
                if (material_autor == null)
                {
                    return false;
                }
                _db.Material_Autores.Remove(material_autor);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Material_autorDto> GetMaterial_autorById(int id)
        {
            Material_autor material_autor = await _db.Material_Autores.FindAsync(id);

            return _mapper.Map<Material_autorDto>(material_autor);
        }

        public async Task<List<Material_autorDto>> GetMaterial_autores()
        {
            List<Material_autor> lista = await _db.Material_Autores.ToListAsync();

            return _mapper.Map<List<Material_autorDto>>(lista);
        }
    }
}
