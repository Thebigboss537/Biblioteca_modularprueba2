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
            List<ReservaDto> lista = _mapper.Map<List<ReservaDto>>(await _db.Reservas/*.Join(_db.Materiales, x => x.Id_material, y => y.Id_material, (x, y) => new { Reserva = x, Material = y }).Select(x => x.Reserva).Join(_db.Usuarios, x => x.Id_usuario, y => y.Id_usuario, (x, y) => new { Reserva = x, Usuario = y }).Select(x => x.Reserva)*/.Include(x => x.Material).Include(x => x.Usuario).Where(x => x.Esta_reservado == true).ToListAsync());

            foreach (var a in lista)
            {
                a.Material.Autores = _mapper.Map<List<Autor>, List<AutorDto>>(await _db.Material_Autores.Where(e => e.Id_material == a.Id_material).Select(e => e.Autor).ToListAsync());

                a.Material.Categorias = _mapper.Map<List<Categoria>, List<CategoriaDto>>(await _db.Material_Categorias.Where(e => e.Id_material == a.Id_material).Select(e => e.Categoria).ToListAsync());

                foreach (var b in a.Material.Autores)
                {
                    a.Material.nombresdeautores = b.Nombre.ToString() + " " + a.Material.nombresdeautores;
                }

                foreach (var c in a.Material.Categorias)
                {
                    a.Material.nombresdecategorias = c.Nombre.ToString() + " " + a.Material.nombresdecategorias;
                }
            }

            return lista;
        }

        public async Task<List<ReservaDto>> GetReservadosid(int id)
        {
            List<ReservaDto> lista = _mapper.Map<List<ReservaDto>>(await _db.Reservas/*.Join(_db.Materiales, x => x.Id_material, y => y.Id_material, (x, y) => new { Reserva = x, Material = y }).Select(x => x.Reserva).Join(_db.Usuarios, x => x.Id_usuario, y => y.Id_usuario, (x, y) => new { Reserva = x, Usuario = y }).Select(x => x.Reserva)*/.Include(x => x.Material).Include(x => x.Usuario).Where(x => x.Esta_reservado == true).Where(x => x.Id_usuario == id).ToListAsync());

            foreach (var a in lista)
            {
                a.Material.Autores = _mapper.Map<List<Autor>, List<AutorDto>>(await _db.Material_Autores.Where(e => e.Id_material == a.Id_material).Select(e => e.Autor).ToListAsync());

                a.Material.Categorias = _mapper.Map<List<Categoria>, List<CategoriaDto>>(await _db.Material_Categorias.Where(e => e.Id_material == a.Id_material).Select(e => e.Categoria).ToListAsync());

                foreach (var b in a.Material.Autores)
                {
                    a.Material.nombresdeautores = b.Nombre.ToString() + " " + a.Material.nombresdeautores;
                }

                foreach (var c in a.Material.Categorias)
                {
                    a.Material.nombresdecategorias = c.Nombre.ToString() + " " + a.Material.nombresdecategorias;
                }
            }

            return lista;
        }

        public async Task<List<MaterialDto>> GetDisponibles()
        {
            List<ReservaDto> reservas = _mapper.Map<List<ReservaDto>>(await _db.Reservas.ToListAsync());

            if (reservas != null)
            {
                foreach (var a in reservas)
                {
                    if (a.Esta_reservado == true)
                    {
                        if (a.Fecha_reserva.Value.AddDays(5) == DateTime.Now)
                        {
                            a.Esta_reservado = false;
                        }
                    }
                }
            }

            List<MaterialDto> materials = _mapper.Map<List<MaterialDto>>(await _db.Materiales.Include(e => e.Editorial).Include(e => e.Sede).Include(e => e.Tipo_material).Where(x => !_db.Reservas.Where(x => x.Esta_reservado == true).Select(x => x.Id_material).Contains(x.Id_material)).ToListAsync());

            
            foreach (var a in materials)
            {
                
                a.Autores = _mapper.Map<List<Autor>, List<AutorDto>>(await _db.Material_Autores.Where(e => e.Id_material == a.Id_material).Select(e => e.Autor).ToListAsync());

                a.Categorias = _mapper.Map<List<Categoria>, List<CategoriaDto>>(await _db.Material_Categorias.Where(e => e.Id_material == a.Id_material).Select(e => e.Categoria).ToListAsync());

                foreach (var b in a.Autores)
                {
                    a.nombresdeautores = b.Nombre.ToString() + " " + a.nombresdeautores;
                }

                foreach (var c in a.Categorias)
                {
                    a.nombresdecategorias = c.Nombre.ToString() + " " + a.nombresdecategorias;
                }
                

            }

            return materials;
        }

        public async Task<ReservaDto> Cancelarreserva(int id)
        {
            Reserva reserva = await _db.Reservas.FindAsync(id);

            reserva.Esta_reservado = false;

            return _mapper.Map<ReservaDto>(reserva);
        }
    }
}
