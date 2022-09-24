namespace Biblioteca_modular.Models.Dto
{
    public class ReservaDto
    {
        
        public int Id_reserva { get; set; }

        public int ?Id_usuario { get; set; }
        public Usuario? Usuario { get; set; }

        public int Id_material { get; set; }
        public MaterialDto ?MaterialDto { get; set; }

        public DateTime ?Fecha_reserva { get; set; }
    }
}
