using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IDevolucionRepositorio
    {
        Task<List<DevolucionDto>> GetDevoluciones();
        Task<DevolucionDto> GetDevolucionById(int id);
        Task<DevolucionDto> CreateUpdate(DevolucionDto devolucionDto);
        Task<bool> DeleteDevolucion(int id);
    }
}
