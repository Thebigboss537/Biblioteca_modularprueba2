namespace Biblioteca_modular.Models.Dto
{
    public class ReservaDto
    {
        
        public int Id_reserva { get; set; }

        public int ?Id_ususario { get; set; }
        public Usuario_autenticacionDto ?UsuarioDto { get; set; }

        public int Id_material { get; set; }
        public MaterialDto ?MaterialDto { get; set; }

        public DateTime ?Fecha_reserva { get; set; }
    }
}
