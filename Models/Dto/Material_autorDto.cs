namespace Biblioteca_modular.Models.Dto
{
    public class Material_autorDto
    {
        public int Id { get; set; }

        public int Id_material { get; set; }
        public Material ?Material { get; set; }

        public int Id_autor { get; set; }
        public Autor ?Autor { get; set; }
    }
}
