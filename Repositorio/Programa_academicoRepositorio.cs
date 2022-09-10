using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class Programa_academicoRepositorio : IPrograma_academicoRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;
        public Programa_academicoRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Programa_academicoDto> CreateUpdate(Programa_academicoDto programa_academicoDto)
        {
            Programa_academico programa_academico = _mapper.Map<Programa_academicoDto, Programa_academico>(programa_academicoDto);
            if (programa_academico.Id_programa_academico > 0)
            {
                _db.Programas_academicos.Update(programa_academico);
            }
            else
            {
                await _db.Programas_academicos.AddAsync(programa_academico);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Programa_academico, Programa_academicoDto>(programa_academico);
        }

        public async Task<bool> DeletePrograma_academico(int id)
        {
            try
            {
                Programa_academico programa_academico = await _db.Programas_academicos.FindAsync(id);
                if (programa_academico == null)
                {
                    return false;
                }
                _db.Programas_academicos.Remove(programa_academico);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Programa_academicoDto> GetPrograma_academicoById(int id)
        {
            Programa_academico programa_academico = await _db.Programas_academicos.FindAsync(id);

            return _mapper.Map<Programa_academicoDto>(programa_academico);
        }

        public async Task<List<Programa_academicoDto>> GetProgramas_academicos()
        {
            List<Programa_academico> lista = await _db.Programas_academicos.ToListAsync();

            return _mapper.Map<List<Programa_academicoDto>>(lista);
        }

       
    }
}
