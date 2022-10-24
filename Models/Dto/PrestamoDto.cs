using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_modular.Models.Dto
{
    public class PrestamoDto
    {
        public int Id_prestamo { get; set; }

        public int ?Cedula { get; set; }

        public int ?Id_usuario { get; set; }
        public UsuarioDto? Usuario { get; set; }

        public int Id_material { get; set; }
        public MaterialDto ?Material { get; set; }

        public DateTime ?Fecha_prestamo { get; set; }

        public DateTime ?Fecha_limite { get; set; }
    }
}
