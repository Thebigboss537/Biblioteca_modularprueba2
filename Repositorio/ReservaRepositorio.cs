using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;
        public ReservaRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ReservaDto> CreateUpdate(ReservaDto reservaDto)
        {
            Reserva reserva = _mapper.Map<ReservaDto, Reserva>(reservaDto);
            if (reserva.Id_reserva > 0)
            {
                _db.Reservas.Update(reserva);
            }
            else
            {
                reserva.Fecha_reserva = DateTime.Now;
                await _db.Reservas.AddAsync(reserva);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Reserva, ReservaDto>(reserva);
        }

        public async Task<bool> DeleteReserva(int id)
        {
            try
            {
                Reserva reserva = await _db.Reservas.FindAsync(id);
                if (reserva == null)
                {
                    return false;
                }
                _db.Reservas.Remove(reserva);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ReservaDto> GetReservaById(int id)
        {
            Reserva reserva = await _db.Reservas.FindAsync(id);

            return _mapper.Map<ReservaDto>(reserva);
        }

        public async Task<List<ReservaDto>> GetReservas()
        {
            List<Reserva> lista = await _db.Reservas.ToListAsync();

            return _mapper.Map<List<ReservaDto>>(lista);
        }
    }
}
