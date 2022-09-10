using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IReservaRepositorio
    {
        Task<List<ReservaDto>> GetReservas();
        Task<ReservaDto> GetReservaById(int id);
        Task<ReservaDto> CreateUpdate(ReservaDto reservaDto);
        Task<bool> DeleteReserva(int id);
    }
}
