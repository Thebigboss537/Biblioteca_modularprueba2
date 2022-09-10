using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_modular.Models
{
    public class Material
    {
        [Key]
        public int Id_material { get; set; }

        [Required]
        public string Titulo { get; set; }

        [ForeignKey("Tipo_material")]
        public int Id_tipo_material { get; set; }
        public Tipo_material Tipo_material{ get; set; }

        [ForeignKey("Editorial")]
        public int ?Id_editorial { get; set; }
        public Editorial Editorial { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        public string Año { get; set; }

        [StringLength(20)]
        public string Formato { get; set; }

        [StringLength(25)]
        public string Idioma { get; set; }

        [StringLength(14)]
        public string ?ISBN { get; set; }

        [ForeignKey("Sede")]
        public int Id_sede { get; set; }
        public Sede ?Sede { get; set; }

        [StringLength(250)]
        public string ?Observacion { get; set; }

        public string ?Archivo { get; set; }
    }
}
