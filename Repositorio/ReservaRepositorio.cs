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
            List<ReservaDto> lista = _mapper.Map<List<ReservaDto>>(await _db.Reservas.Join(_db.Materiales, x => x.Id_material, y => y.Id_material, (x, y) => new { Reserva = x, Material = y }).Select(x => x.Reserva).Join(_db.Usuarios, x => x.Id_usuario, y => y.Id_usuario, (x, y) => new { Reserva = x, Usuario = y }).Select(x => x.Reserva).Include(x => x.Material).Include(x => x.Usuario).ToListAsync());

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
            List<ReservaDto> lista = _mapper.Map<List<ReservaDto>>(await _db.Reservas.Join(_db.Materiales, x => x.Id_material, y => y.Id_material, (x, y) => new { Reserva = x, Material = y }).Select(x => x.Reserva).Join(_db.Usuarios, x => x.Id_usuario, y => y.Id_usuario, (x, y) => new { Reserva = x, Usuario = y }).Select(x => x.Reserva).Include(x => x.Material).Include(x => x.Usuario).Where(x => x.Id_usuario == id).ToListAsync());

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

            /*List<Material_autor> material = await _db.Materiales.Join(_db.Material_Autores, x => x.Id_material, y => y.Id_material, (x, y) => new { Materiales = x, Material_Autores = y }).Select(e => e.Material_Autores).Include(e => e.Material).Include(e => e.Autor).Include(e => e.Material.Editorial).Include(e => e.Material.Sede).Include(e => e.Material.Tipo_material).ToListAsync();*/

            /*var a = await _db.Material_Autores.Include(e => e.Material).Include(e => e.Autor).Join(_db.Material_Categorias, x => x.Id_material, y => y.Id_material, (x, y) => new { Material_Autores = x, Material_Categorias = y }).ToListAsync();*/

            List<MaterialDto> materials = _mapper.Map<List<MaterialDto>>(await _db.Materiales.Include(e => e.Editorial).Include(e => e.Sede).Include(e => e.Tipo_material).Where(x => !_db.Reservas.Select(x => x.Id_material).Contains(x.Id_material)).ToListAsync());   /* AddRange(_db.Material_Autores.Where(e => e.Id_material == 1).Select(e => e.Autor).;*/



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
                /*a.Autores = await _db.Material_Autores.Where(e => e.Id_material == a.Id_material).Select(e => e.Autor).ToListAsync();*/

            }


            /*var a = await _db.Autores.Join(_db.Material_Autores, x => x.Id_autor, y => y.Id_autor, (x, y) => new { Autores = x, Material_Autores = y }).Join(_db.Materiales, x => x.Material_Autores.Id_material, y => y.Id_material, (x, y) => new { Material_Autores = x, Materiales = y }).ToListAsync(); /*.Join(_db.Material_Categorias, x => x.Id_material, y => y.Id_material, (x, y) => new { Materiales = x, Material_Categorias = y }).Join(_db.Categorias, x => x.Material_Categorias.Id_categoria, y => y.Id_categoria, (x, y) => new { Material_Categorias = x, Categorias = y }).ToListAsync();*/

            /*var d = await _db.Materiales.Join(_db.Material_Autores, x => x.Id_material, y => y.Id_material, (x, y) => new { Materiales = x, Material_Autores = y }).Select(e => e.Material_Autores).Include(e => e.Autor).Include(e => e.Material).Include(e => e.Material.Editorial).Include(e => e.Material.Sede).Include(e => e.Material.Tipo_material).ToListAsync();   /*.Join(_db.Material_Categorias, x => x.Materiales.Id_material, y => y.Id_material, (x, y) => new { Materiales = x, Material_Categorias = y }).ToListAsync();*/

            /*.Select(e => e.Materiales).Include(e => e.Material_Autores).Include(e => e.Materiales.Editorial).Include(e => e.Materiales.Sede).ToListAsync();*/

            return materials;
        }
    }
}
