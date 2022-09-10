using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class Tipo_materialRepositorio : ITipo_materialRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;

        public Tipo_materialRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Tipo_materialDto> CreateUpdate(Tipo_materialDto Tipo_MaterialDto)
        {
            Tipo_material Tipo_material = _mapper.Map<Tipo_materialDto, Tipo_material>(Tipo_MaterialDto);
            if(Tipo_material.Id_tipo_material > 0)
            {
                _db.Tipo_materiales.Update(Tipo_material);
            }
            else
            {
               await _db.Tipo_materiales.AddAsync(Tipo_material);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Tipo_material, Tipo_materialDto>(Tipo_material);
        }

        public async Task<bool> DeleteTipo_material(int id)
        {
            try
            {
                Tipo_material Tipo_material = await _db.Tipo_materiales.FindAsync(id);
                if (Tipo_material == null)
                {
                    return false;
                }
                _db.Tipo_materiales.Remove(Tipo_material);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Tipo_materialDto>> GetTipo_material()
        {
            List<Tipo_material> lista = await _db.Tipo_materiales.ToListAsync();

            return _mapper.Map<List<Tipo_materialDto>>(lista);
        }

        public async Task<Tipo_materialDto> GetTipo_materialById(int id)
        {
            Tipo_material Tipo_material = await _db.Tipo_materiales.FindAsync(id);

            return _mapper.Map<Tipo_materialDto>(Tipo_material);
        }
    }
}
