using System.ComponentModel.DataAnnotations;

namespace Biblioteca_modular.Models
{
    public class Editorial
    {
        [Key]
        public int Id_editorial { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

    }
}
