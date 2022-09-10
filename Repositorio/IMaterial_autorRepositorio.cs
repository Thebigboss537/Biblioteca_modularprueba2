using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IMaterial_autorRepositorio
    {
        Task<List<Material_autorDto>> GetMaterial_autores();
        Task<Material_autorDto> GetMaterial_autorById(int id);
        Task<Material_autorDto> CreateUpdate(Material_autorDto material_autorDto);
        Task<bool> DeleteMaterial_autor(int id);
    }
}
