using Biblioteca_modular.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_modular.Models
{
    public class Usuario
    {
        [Key]
        public int Id_usuario { get; set; }

        public int Username { get; set; }

        public Byte[]? PasswordHash { get; set; }

        public Byte[]? PasswordSalt { get; set; }

        [ForeignKey("Rol")]
        public int Id_rol { get; set; }
        public Rol? Rol { get; set; }
    }
}
