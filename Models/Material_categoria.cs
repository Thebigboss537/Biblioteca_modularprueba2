
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_modular.Models
{
    public class Material_categoria
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Material")]
        public int Id_material { get; set; }
        public Material ?Material { get; set; }

        [ForeignKey("Categoria")]
        public int Id_categoria { get; set; }
        public Categoria ?Categoria { get; set; }
    }
}
