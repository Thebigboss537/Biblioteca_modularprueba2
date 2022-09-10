using Biblioteca_modular.Util;

namespace Biblioteca_modular.Models.Dto
{
    public class ClienteDto
    {
        public int Id_cliente { get; set; }

        public int Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Id_programa_academico { get; set; }
        public Programa_academico ?Programa_academico { get; set; }

        public string Telefono { get; set; }

        public Semestre Semestre { get; set; }

        public string Correo_electronico { get; set; }

        public int? Id_usuario { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
