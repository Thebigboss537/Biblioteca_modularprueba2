namespace Biblioteca_modular.Models.Dto
{
    public class ReservaDto
    {
        
        public int Id_reserva { get; set; }

        public int ?Id_usuario { get; set; }
        public UsuarioDto? Usuario { get; set; }

        public int Id_material { get; set; }
        public MaterialDto ?Material { get; set; }

        public DateTime ?Fecha_reserva { get; set; }

        public bool ?Esta_reservado { get; set; }
    }
}
