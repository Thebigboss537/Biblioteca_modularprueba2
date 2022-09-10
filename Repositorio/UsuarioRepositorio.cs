using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Biblioteca_modular.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        /*private readonly DataContext _db;
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UsuarioRepositorio(DataContext db, IMapper mapper, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UsuarioDto> CreateUpdate(UsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<UsuarioDto, Usuario>(usuarioDto);
            
            if (usuario.Id_usuario > 0)
            {
                var a = _db.Usuarios.AsNoTracking().Where(e => e.Cedula == usuarioDto.Cedula).FirstOrDefault();
                usuario.PasswordHash = a.PasswordHash;
                usuario.PasswordSalt = a.PasswordSalt;
                _db.Usuarios.Update(usuario);
            }
            else
            {
                await _db.Usuarios.AddAsync(usuario);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Usuario, UsuarioDto>(usuario);
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            try
            {
                Usuario usuario = await _db.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return false;
                }
                _db.Usuarios.Remove(usuario);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UsuarioDto> GetUsuarioById(int id)
        {
            Usuario usuario  = await _db.Usuarios.FindAsync(id);

            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<List<UsuarioDto>> GetUsuarios()
        {
            List<Usuario> lista = null;//esto se debe quitar
            List<Usuario> lista = await _db.Usuarios.Include(e => e.Programa_academico).Include(e => e.Rol).ToListAsync();

            var a = _mapper.Map<List<UsuarioDto>>(lista);

            return a;
        }

        // TODO: Debería pertenecer a otro Módulo que no es usuario
        public async Task<List<Programa_academicoDto>> GetProgramas_academicos()
        {
            List<Programa_academico> lista = await _db.Programas_academicos.ToListAsync();

            return _mapper.Map<List<Programa_academicoDto>>(lista);
        }
        public async Task<List<RolDto>> GetRoles()
        {
            List<Rol> lista = await _db.Roles.ToListAsync();

            return _mapper.Map<List<RolDto>>(lista);
        }

        public async Task<string> Login(string Nombre_usuario, string password)
        {
            var user = await _db.Usuarios.FirstOrDefaultAsync(x => x.Cedula.ToString().ToLower().Equals(Nombre_usuario.ToString().ToLower()));

            if (user == null)
            {
                return "nouser";
            }
            else if (!VerificarPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return "wrongpassword";
            }
            else
            {
               return CrearToken(user);
            }
        }

        public async Task<string> Register(Usuario usuario, string password)
        {

            try
            {
                if (await UserExiste(usuario.Cedula.ToString()))
                {
                    return "existe";
                }

                CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                usuario.PasswordHash = passwordHash;
                usuario.PasswordSalt = passwordSalt;
                usuario.id_rol = 2;

                await _db.Usuarios.AddAsync(usuario);
                await _db.SaveChangesAsync();
                return CrearToken(usuario);
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        public async Task<bool> UserExiste(string Nombre_usuario)
        {
            if (await _db.Usuarios.AnyAsync(x => x.Cedula.ToString().ToLower().Equals(Nombre_usuario.ToLower())))
            {
                return true;
            }
            return false;
        }


        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        public bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwrodSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwrodSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CrearToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id_usuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.Cedula.ToString()),
                new Claim(ClaimTypes.Role, usuario.Id_rol.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }*/
    }
}
