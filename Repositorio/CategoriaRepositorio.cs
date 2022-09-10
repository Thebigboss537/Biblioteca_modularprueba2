using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;

        public CategoriaRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CategoriaDto> CreateUpdate(CategoriaDto CategoriaDto)
        {
            Categoria Categoria = _mapper.Map<CategoriaDto, Categoria>(CategoriaDto);
            if (Categoria.Id_categoria > 0)
            {
                _db.Categorias.Update(Categoria);
            }
            else
            {
                await _db.Categorias.AddAsync(Categoria);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Categoria, CategoriaDto>(Categoria);
        }

        public async Task<bool> DeleteCategoria(int id)
        {
            try
            {
                Categoria Categoria = await _db.Categorias.FindAsync(id);
                if (Categoria == null)
                {
                    return false;
                }
                _db.Categorias.Remove(Categoria);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CategoriaDto>> GetCategorias()
        {
            List<Categoria> lista = await _db.Categorias.ToListAsync();

            return _mapper.Map<List<CategoriaDto>>(lista);
        }

        public async Task<CategoriaDto> GetCategoriaById(int id)
        {
            Categoria Categoria = await _db.Categorias.FindAsync(id);

            return _mapper.Map<CategoriaDto>(Categoria);
        }
    }
}