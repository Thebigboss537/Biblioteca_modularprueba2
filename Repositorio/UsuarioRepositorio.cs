using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DataContext _db;
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
                usuario.Id_usuario = Convert.ToInt32(_db.Usuarios_autenticacion.FirstOrDefault(e => e.Username == usuario.Cedula).Id_usuario_autenticacion);
                _db.Usuarios.Update(usuario);
            }
            else
            {
                Usuario_autenticacion usuario_autenticacion = new Usuario_autenticacion { Username = usuarioDto.Cedula };
                usuario_autenticacion.Id_rol = 3;
                await _db.Usuarios_autenticacion.AddAsync(usuario_autenticacion);
                await _db.SaveChangesAsync();
                usuario.Id_usuario_autenticacion = usuario_autenticacion.Id_usuario_autenticacion;
                await _db.Usuarios.AddAsync(usuario);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Usuario, UsuarioDto>(usuario);
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            try
            {
                Usuario cliente = await _db.Usuarios.FindAsync(id);
                if (cliente == null)
                {
                    return false;
                }
                _db.Usuarios.Remove(cliente);
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
            Usuario cliente = _db.Usuarios.Include(e => e.Programa_academico).FirstOrDefault(e => e.Id_usuario == id);

            return _mapper.Map<UsuarioDto>(cliente);
        }

        public async Task<List<UsuarioDto>> GetUsuarios()
        {
            List<Usuario> lista = await _db.Usuarios.Include(e => e.Programa_academico).ToListAsync();

            return _mapper.Map<List<UsuarioDto>>(lista);
        }

        public async Task<List<Programa_academicoDto>> GetProgramas_academicos()
        {
            List<Programa_academico> lista = await _db.Programas_academicos.ToListAsync();

            return _mapper.Map<List<Programa_academicoDto>>(lista);
        }
        
        /*public async Task<List<RolDto>> GetRoles()
        {
            List<Rol> lista = await _db.Roles.ToListAsync();

            return _mapper.Map<List<RolDto>>(lista);
        }*/

        /*public async Task<string> Login(string Nombre_cliente, string password)
        {
            
            var user = await _db.Clientes.FirstOrDefaultAsync(x => x.Cedula.ToString().ToLower().Equals(Nombre_cliente.ToString().ToLower()));

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
        }*/

        /*public async Task<string> Register(Cliente cliente, string password)
        {

            try
            {
                if (await UserExiste(cliente.Cedula.ToString()))
                {
                    return "existe";
                }

                CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                cliente.PasswordHash = passwordHash;
                cliente.PasswordSalt = passwordSalt;
                cliente.id_rol = 2;

                await _db.Clientes.AddAsync(cliente);
                await _db.SaveChangesAsync();
                return CrearToken(cliente);
            }
            catch (Exception ex)
            {
                return "error";
            }
        }*/

        /*public async Task<bool> UserExiste(string Nombre_cliente)
        {
            if (await _db.Clientes.AnyAsync(x => x.Cedula.ToString().ToLower().Equals(Nombre_cliente.ToLower())))
            {
                return true;
            }
            return false;
        }*/


        /*private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }*/

        /*public bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwrodSalt)
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
        }*/

        /*private string CrearToken(Cliente cliente)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, cliente.Id_cliente.ToString()),
                new Claim(ClaimTypes.Name, cliente.Cedula.ToString()),
                new Claim(ClaimTypes.Role, cliente.id_rol.ToString())
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
