using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class PrestamoRepositorio : IPrestamoRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;
        public PrestamoRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PrestamoDto> CreateUpdate(PrestamoDto prestamoDto)
        {
            Prestamo prestamo = _mapper.Map<PrestamoDto, Prestamo>(prestamoDto);
            /*if (prestamo.Id_prestamo > 0)
            {
                _db.Prestamos.Update(prestamo);
            }
            else
            {
                var a = _db.Usuarios.Where(e => e.cedula == prestamoDto.Cedula).FirstOrDefault();

                prestamo.Id_ususario = a.Id_usuario;
                prestamo.Fecha_prestamo = DateTime.Now;
                prestamo.Fecha_limite = DateTime.Now.AddDays(10);
                await _db.Prestamos.AddAsync(prestamo);
            }
            await _db.SaveChangesAsync();*/
            return _mapper.Map<Prestamo, PrestamoDto>(prestamo);
        }

        public async Task<bool> DeletePrestamo(int id)
        {
            try
            {
                Prestamo prestamo = await _db.Prestamos.FindAsync(id);
                if (prestamo == null)
                {
                    return false;
                }
                _db.Prestamos.Remove(prestamo);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PrestamoDto> GetPrestamoById(int id)
        {
            Prestamo prestamo = await _db.Prestamos.FindAsync(id);

            return _mapper.Map<PrestamoDto>(prestamo);
        }

        public async Task<List<PrestamoDto>> GetPrestamos()
        {
            List<Prestamo> lista = await _db.Prestamos.ToListAsync();

            return _mapper.Map<List<PrestamoDto>>(lista);
        }
    }
}
