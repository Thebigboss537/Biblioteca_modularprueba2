using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IMaterial_categoriaRepositorio
    {
        Task<List<Material_categoriaDto>> GetMaterial_categorias();
        Task<Material_categoriaDto> GetMaterial_categoriaById(int id);
        Task<Material_categoriaDto> CreateUpdate(Material_categoriaDto material_categoriaDto);
        Task<bool> DeleteMaterial_categoria(int id);
    }
}
