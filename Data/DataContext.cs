using Biblioteca_modular.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_modular.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Devolucion> Devoluciones { get; set; }

        public DbSet<Editorial> Editoriales { get; set; }

        public DbSet<Material> Materiales { get; set; }

        public DbSet<Material_autor> Material_Autores { get; set; }

        public DbSet<Material_categoria> Material_Categorias { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }

        public DbSet<Programa_academico> Programas_academicos { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Sede> Sedes { get; set; }

        public DbSet<Tipo_material> Tipo_materiales { get; set; }

        public DbSet<Usuario_autenticacion> Usuarios_autenticacion { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

