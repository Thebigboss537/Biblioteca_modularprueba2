namespace Biblioteca_modular.Models.Dto
{
    public class Material_categoriaDto
    {
        public int Id { get; set; }

        public int Id_material { get; set; }
        public Material ?Material { get; set; }

        public int Id_categoria { get; set; }
        public Categoria ?Categoria { get; set; }
    }
}
