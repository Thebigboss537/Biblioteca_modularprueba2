using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IPrestamoRepositorio
    {
        Task<List<PrestamoDto>> GetPrestamos();
        Task<List<MaterialDto>> GetDisponibles();
        Task<List<PrestamoDto>> GetPrestadosid(int id);
        Task<PrestamoDto> GetPrestamoById(int id);
        Task<PrestamoDto> CreateUpdate(PrestamoDto prestamoDto);
        Task<bool> DeletePrestamo(int id);
        Task<UsuarioDto> ExistUsuario(PrestamoDto prestamoDto);
    }
}
