using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class AutorRepositorio : IAutorRepositorio
    {

        private readonly DataContext _db;
        private IMapper _mapper;
        public AutorRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<AutorDto> CreateUpdate(AutorDto autorDto)
        {
            Autor autor = _mapper.Map<AutorDto, Autor>(autorDto);
            if (autor.Id_autor > 0)
            {
                _db.Autores.Update(autor);
            }
            else
            {
                await _db.Autores.AddAsync(autor);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Autor, AutorDto>(autor);
        }

        public async Task<bool> DeleteAutor(int id)
        {
            try
            {
                Autor autor = await _db.Autores.FindAsync(id);
                if (autor == null)
                {
                    return false;
                }
                _db.Autores.Remove(autor);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<AutorDto> GetAutorById(int id)
        {
            Autor autor = await _db.Autores.FindAsync(id);

            return _mapper.Map<AutorDto>(autor);
        }

        public async Task<List<AutorDto>> GetAutores()
        {
            List<Autor> lista = await _db.Autores.ToListAsync();

            return _mapper.Map<List<AutorDto>>(lista);
        }
    }
}
