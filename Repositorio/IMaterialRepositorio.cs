using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IMaterialRepositorio
    {
        Task<List<MaterialDto>> GetMateriales();
        Task<MaterialDto> GetMaterialById(int id);
        Task<MaterialDto> CreateUpdate(MaterialDto MaterialDto);
        Task<bool> DeleteMaterial(int id);
    }
}
