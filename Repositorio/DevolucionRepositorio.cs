using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class DevolucionRepositorio : IDevolucionRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;
        public DevolucionRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DevolucionDto> CreateUpdate(DevolucionDto devolucionDto)
        {
            
            Devolucion devolucion = _mapper.Map<DevolucionDto, Devolucion>(devolucionDto);
            if (devolucion.Id_devolucion > 0)
            {
                _db.Devoluciones.Update(devolucion);
            }
            else
            {
                devolucion.Fecha_devolucion = DateTime.Now;

                await _db.Devoluciones.AddAsync(devolucion);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Devolucion, DevolucionDto>(devolucion);
        }

        public async Task<bool> DeleteDevolucion(int id)
        {
            try
            {
                Devolucion devolucion = await _db.Devoluciones.FindAsync(id);
                if (devolucion == null)
                {
                    return false;
                }
                _db.Devoluciones.Remove(devolucion);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DevolucionDto> GetDevolucionById(int id)
        {
            Devolucion devolucion = await _db.Devoluciones.FindAsync(id);

            return _mapper.Map<DevolucionDto>(devolucion);
        }

        public async Task<List<DevolucionDto>> GetDevoluciones()
        {
            List<Devolucion> lista = await _db.Devoluciones.ToListAsync();

            return _mapper.Map<List<DevolucionDto>>(lista);
        }
    }
}
