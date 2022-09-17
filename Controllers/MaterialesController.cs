#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;
using Biblioteca_modular.Repositorio;
using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Controllers
{
    [Route("api/materiales/")]
    [ApiController]
    public class MaterialesController : ControllerBase
    {
        private readonly IMaterialRepositorio _MaterialRepositorio;
        private readonly ITipo_materialRepositorio _Tipo_MatetialRepositorio;
        private readonly IEditorialRepositorio _EditorialRepositorio;
        private readonly ISedeRepositorio _SedeRepositorio;
        private readonly ICategoriaRepositorio _CategoriaRepositorio;
        private readonly IAutorRepositorio _AutorRepositorio;
        private readonly IMaterial_autorRepositorio _Material_autorRepositorio;
        private readonly IMaterial_categoriaRepositorio _Material_categoriaRepositorio;
        protected ResponseDto _response;

        private readonly IWebHostEnvironment _enviroment;

        public MaterialesController(IMaterialRepositorio MaterialRepositorio, IWebHostEnvironment env, 
            ITipo_materialRepositorio Tipo_MaterialRepositorio, IEditorialRepositorio EditorialRepositorio, 
            ISedeRepositorio SedeRepositorio, ICategoriaRepositorio CategoriaRepositorio, IAutorRepositorio AutorRepositorio, 
            IMaterial_autorRepositorio Material_AutorRepositorio, IMaterial_categoriaRepositorio Material_CategoriaRepositorio)
        {
            
            _MaterialRepositorio = MaterialRepositorio;
            _Tipo_MatetialRepositorio = Tipo_MaterialRepositorio;
            _EditorialRepositorio = EditorialRepositorio;
            _SedeRepositorio = SedeRepositorio;
            _CategoriaRepositorio = CategoriaRepositorio;
            _AutorRepositorio = AutorRepositorio;
            _Material_autorRepositorio = Material_AutorRepositorio;
            _Material_categoriaRepositorio = Material_CategoriaRepositorio;
            _response = new ResponseDto();
            _enviroment = env;
        }

        // GET: api/Materiales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetMateriales()
        {
            try
            {
                var lista = await _MaterialRepositorio.GetMateriales();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Materiales";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/Materiales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var material = await _MaterialRepositorio.GetMaterialById(id);
            if (material == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Material no existe";
                return NotFound(_response);
            }
            _response.Result = material;
            _response.DisplayMessage = "Informacion del Material";
            return Ok(_response);
        }

        // PUT: api/Materiales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, MaterialDto MaterialDto)
        {
            try
            {

                if (MaterialDto.Archivo != null)
                {

                    var filePath = Path.Combine(_enviroment.ContentRootPath, "Archivos", MaterialDto.Archivo.FileName.Replace(MaterialDto.Archivo.FileName, MaterialDto.Titulo + ".pdf"));

                    var filepath2 = Path.ChangeExtension(filePath, ".pdf");

                    using (var stream = System.IO.File.Create(filepath2))
                    {
                        await MaterialDto.Archivo.CopyToAsync(stream);
                    }

                    MaterialDto.Ruta = filepath2;
                }

                MaterialDto model = await _MaterialRepositorio.CreateUpdate(MaterialDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el Material";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Materiales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("crearmaterial")]
        public async Task<ActionResult<Material>> PostAutor([FromForm]MaterialDto MaterialDto)
        {
            try
            {

                if (MaterialDto.Archivo != null)
                {

                    var filePath = Path.Combine(_enviroment.ContentRootPath,"Archivos", MaterialDto.Archivo.FileName.Replace(MaterialDto.Archivo.FileName, MaterialDto.Titulo + ".pdf"));

                    var filepath2 = Path.ChangeExtension(filePath, ".pdf");

                    using (var stream = System.IO.File.Create(filepath2))
                    {
                        await MaterialDto.Archivo.CopyToAsync(stream);
                    }

                    MaterialDto.Ruta = filepath2;
                }


                Material_autorDto material_autorDto = new Material_autorDto();
                Material_categoriaDto material_categoriaDto = new Material_categoriaDto();



                MaterialDto model = await _MaterialRepositorio.CreateUpdate(MaterialDto);

                foreach (var a in MaterialDto.Autores)
                {
                    material_autorDto.Id_autor = a.Id_autor;
                    material_autorDto.Id_material = model.Id_material;
                }

                foreach (var b in MaterialDto.Categorias)
                {
                    material_categoriaDto.Id_categoria = b.Id_categoria;
                    material_categoriaDto.Id_material = model.Id_material;
                }

                

                material_autorDto = await _Material_autorRepositorio.CreateUpdate(material_autorDto);
                material_categoriaDto = await _Material_categoriaRepositorio.CreateUpdate(material_categoriaDto);

                _response.Result = model;
                return CreatedAtAction("GetMaterial", new { id = model.Id_material }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el Material";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }


        [HttpGet("crearmaterial")]
        public async Task<ActionResult<Material>> Getdropdownlists()
        {
            try
            {
                gets get = new gets();


                get.tipo_material = await _Tipo_MatetialRepositorio.GetTipo_material();
                get.editorial = await _EditorialRepositorio.GetEditorial();
                get.sede = await _SedeRepositorio.GetSede();
                get.categoria = await _CategoriaRepositorio.GetCategorias();
                get.autor = await _AutorRepositorio.GetAutores();

                _response.Result = get;
                _response.DisplayMessage = "Lista dropdownslists";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // DELETE: api/Materiales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            try
            {
                bool estaeliminado = await _MaterialRepositorio.DeleteMaterial(id);
                if (estaeliminado)
                {
                    _response.Result = estaeliminado;
                    _response.DisplayMessage = "Material eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el Material";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        public class gets
        {
            public List<Tipo_materialDto> tipo_material { get; set; }

            public List<EditorialDto> editorial { get; set; }

            public List<SedeDto> sede { get; set; }

            public List<CategoriaDto> categoria { get; set; }

            public List<AutorDto> autor { get; set; }
        }





    }
}