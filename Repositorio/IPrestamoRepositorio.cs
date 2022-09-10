using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IPrestamoRepositorio
    {
        Task<List<PrestamoDto>> GetPrestamos();
        Task<PrestamoDto> GetPrestamoById(int id);
        Task<PrestamoDto> CreateUpdate(PrestamoDto prestamoDto);
        Task<bool> DeletePrestamo(int id);
    }
}
