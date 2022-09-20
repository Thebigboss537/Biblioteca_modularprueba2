namespace Biblioteca_modular.Models.Dto
{
    public class Material_archivoDto
    {
        public int Id_material { get; set; }

        public string? Titulo { get; set; }

        public IFormFile? Archivo { get; set; }

        public string ?Ruta { get; set; }
    }
}
