using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface ICategoriaRepositorio
    {
        Task<List<CategoriaDto>> GetCategorias();

        Task<CategoriaDto> GetCategoriaById(int id);

        Task<CategoriaDto> CreateUpdate(CategoriaDto Categoria);

        Task<bool> DeleteCategoria(int id);
    }
}