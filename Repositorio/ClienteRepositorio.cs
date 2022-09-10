using AutoMapper;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DataContext _db;
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        public ClienteRepositorio(DataContext db, IMapper mapper, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ClienteDto> CreateUpdate(ClienteDto clienteDto)
        {
            Cliente cliente = _mapper.Map<ClienteDto, Cliente>(clienteDto);

            if (cliente.Id_cliente > 0)
            {
                cliente.Id_usuario = Convert.ToInt32(_db.Usuarios.FirstOrDefault(e => e.Username == cliente.Cedula).Id_usuario);
                _db.Clientes.Update(cliente);
            }
            else
            {
                Usuario usuario = new Usuario { Username = clienteDto.Cedula };
                usuario.Id_rol = 3;
                await _db.Usuarios.AddAsync(usuario);
                await _db.SaveChangesAsync();
                cliente.Id_usuario = usuario.Id_usuario;
                await _db.Clientes.AddAsync(cliente);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Cliente, ClienteDto>(cliente);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            try
            {
                Cliente cliente = await _db.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return false;
                }
                _db.Clientes.Remove(cliente);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ClienteDto> GetClienteById(int id)
        {
            Cliente cliente = _db.Clientes.Include(e => e.Programa_academico).FirstOrDefault(e => e.Id_cliente == id);

            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task<List<ClienteDto>> GetClientes()
        {
            List<Cliente> lista = await _db.Clientes.Include(e => e.Programa_academico).ToListAsync();

            return _mapper.Map<List<ClienteDto>>(lista);
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
