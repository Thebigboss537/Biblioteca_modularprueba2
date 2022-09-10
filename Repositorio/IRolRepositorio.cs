using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IRolRepositorio
    {
        Task<List<RolDto>> GetRoles();
        Task<RolDto> GetRolById(int id);
        Task<RolDto> CreateUpdate(RolDto autorDto);
        Task<bool> DeleteRol(int id);
    }
}
