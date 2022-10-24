using Biblioteca_modular.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_modular.Models
{
    public class Usuario
    {
        [Key]
        public int Id_usuario { get; set; }

        [Required]
        public int Cedula { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string Apellido { get; set; }

        [ForeignKey("Programa_academico")]
        public int ?Id_programa_academico { get; set; }
        public Programa_academico ?Programa_academico { get; set; }

        [Required]
        public string Telefono { get; set; }

        public Semestre ?Semestre { get; set; }

        [Required]
        public string Correo_electronico { get; set; }

        [ForeignKey("Usuario_autenticacion")]
        public int? Id_usuario_autenticacion { get; set; }
        public Usuario_autenticacion ?Usuario_autenticacion { get; set; }
    }
}
