namespace Biblioteca_modular.Models.Dto
{
    public class PrestamoDto
    {
        public int Id_prestamo { get; set; }

        public int ?Cedula { get; set; }

        public int ?Id_ususario { get; set; }
        public UsuarioDto ?UsuarioDto { get; set; }

        public int Id_material { get; set; }
        public MaterialDto ?MaterialDto { get; set; }

        public DateTime ?Fecha_prestamo { get; set; }

        public DateTime ?Fecha_limite { get; set; }
    }
}
