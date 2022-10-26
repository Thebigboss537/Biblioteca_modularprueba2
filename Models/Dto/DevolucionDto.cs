namespace Biblioteca_modular.Models.Dto
{
    public class DevolucionDto
    {
        
        public int Id_devolucion { get; set; }

        public int Id_prestamo { get; set; }
        public PrestamoDto ?PrestamoDto { get; set; }

        public DateTime ?Fecha_devolucion { get; set; }

        public string Observacion { get; set; }

    }
}
