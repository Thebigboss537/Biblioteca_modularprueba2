using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class SedeRepositorio : ISedeRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;

        public SedeRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<SedeDto> CreateUpdate(SedeDto SedeDto)
        {
            Sede Sede = _mapper.Map<SedeDto, Sede>(SedeDto);
            if (Sede.Id_sede > 0)
            {
                _db.Sedes.Update(Sede);
            }
            else
            {
                await _db.Sedes.AddAsync(Sede);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Sede, SedeDto>(Sede);
        }

        public async Task<bool> DeleteSede(int id)
        {
            try
            {
                Sede Sede = await _db.Sedes.FindAsync(id);
                if (Sede == null)
                {
                    return false;
                }
                _db.Sedes.Remove(Sede);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<SedeDto>> GetSede()
        {
            List<Sede> lista = await _db.Sedes.ToListAsync();

            return _mapper.Map<List<SedeDto>>(lista);
        }

        public async Task<SedeDto> GetSedeById(int id)
        {
            Sede Sede = await _db.Sedes.FindAsync(id);

            return _mapper.Map<SedeDto>(Sede);
        }
    }
}