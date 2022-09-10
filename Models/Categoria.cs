using System.ComponentModel.DataAnnotations;

namespace Biblioteca_modular.Models
{
    public class Categoria
    {
        [Key]
        public int Id_categoria { get; set; }

        [Required]
        [StringLength(70)]
        public string Nombre { get; set; }
    }
}
