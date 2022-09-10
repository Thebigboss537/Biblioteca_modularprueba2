using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_modular.Models
{
    public class Material_autor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Material")]
        public int Id_material { get; set; }
        public Material ?Material { get; set; }

        [ForeignKey("Autor")]
        public int Id_autor { get; set; }
        public Autor ?Autor { get; set; }
    }
}
