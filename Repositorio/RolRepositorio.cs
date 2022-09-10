using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class RolRepositorio :IRolRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;

        public RolRepositorio(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<RolDto> CreateUpdate(RolDto rolDto)
        {
            Rol rol = _mapper.Map<RolDto, Rol>(rolDto);
            if (rol.Id_rol > 0)
            {
                _db.Roles.Update(rol);
            }
            else
            {
                await _db.Roles.AddAsync(rol);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Rol, RolDto>(rol);
        }

        public async Task<bool> DeleteRol(int id)
        {
            try
            {
                Rol rol = await _db.Roles.FindAsync(id);
                if (rol == null)
                {
                    return false;
                }
                _db.Roles.Remove(rol);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<RolDto>> GetRoles()
        {
            List<Rol> lista = await _db.Roles.ToListAsync();

            return _mapper.Map<List<RolDto>>(lista);
        }

        public async Task<RolDto> GetRolById(int id)
        {
            Rol rol = await _db.Roles.FindAsync(id);

            return _mapper.Map<RolDto>(rol);
        }
    }
}
