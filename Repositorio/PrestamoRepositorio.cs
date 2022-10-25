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
            if (prestamo.Id_prestamo > 0)
            {
                _db.Prestamos.Update(prestamo);
            }
            else
            {
                var a = _db.Usuarios.Where(e => e.Cedula == prestamoDto.Cedula).FirstOrDefault();

                prestamo.Id_usuario = a.Id_usuario;
                prestamo.Fecha_prestamo = DateTime.Now;
                prestamo.Fecha_limite = DateTime.Now.AddDays(10);
                await _db.Prestamos.AddAsync(prestamo);
            }
            await _db.SaveChangesAsync();
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
            List<PrestamoDto> lista = _mapper.Map<List<PrestamoDto>>(await _db.Prestamos.Join(_db.Materiales, x => x.Id_material, y => y.Id_material, (x, y) => new { Prestamo = x, Material = y }).Select(x => x.Prestamo).Join(_db.Usuarios, x => x.Id_usuario, y => y.Id_usuario, (x, y) => new { Prestamo = x, Usuario = y }).Select(x => x.Prestamo).Include(x => x.Material).Include(x => x.Usuario).ToListAsync());

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

        public async Task<List<PrestamoDto>> GetPrestadosid(int id)
        {
            List<PrestamoDto> lista = _mapper.Map<List<PrestamoDto>>(await _db.Reservas.Join(_db.Materiales, x => x.Id_material, y => y.Id_material, (x, y) => new { Prestamo = x, Material = y }).Select(x => x.Prestamo).Join(_db.Usuarios, x => x.Id_usuario, y => y.Id_usuario, (x, y) => new { Prestamo = x, Usuario = y }).Select(x => x.Prestamo).Include(x => x.Material).Include(x => x.Usuario).Where(x => x.Id_usuario == id).ToListAsync());

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

            List<MaterialDto> materials = _mapper.Map<List<MaterialDto>>(await _db.Materiales.Include(e => e.Editorial).Include(e => e.Sede).Include(e => e.Tipo_material).Where(x => !_db.Prestamos.Join(_db.Devoluciones, x => x.Id_prestamo, y => y.Id_prestamo, (x, y) => new { Prestamo = x, Devolucion = y }).Include(x => x.Devolucion).Where(x => x.Devolucion.Fecha_devolucion == null).Select(x => x.Prestamo).Select(x => x.Id_material).Contains(x.Id_material)).ToListAsync());



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
    }
}
