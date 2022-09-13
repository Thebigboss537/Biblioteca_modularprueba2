using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_modular.Models
{
    public class Reserva
    {
        [Key]
        public int Id_reserva { get; set; }

        [ForeignKey("Usuario")]
        public int Id_usuario { get; set; }
        public Usuario_autenticacion ?Usuario { get; set; }

        [ForeignKey("Material")]
        public int Id_material { get; set; }
        public Material ?Material { get; set; }

        [Required]
        public DateTime Fecha_reserva { get; set; }
    }
}
