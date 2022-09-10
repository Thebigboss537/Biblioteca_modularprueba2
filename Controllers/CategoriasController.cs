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
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        protected ResponseDto _response;

        public CategoriasController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            try
            {
                var lista = await _categoriaRepositorio.GetCategorias();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de categorias";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _categoriaRepositorio.GetCategoriaById(id);
            if (categoria == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Categoria no existe";
                return NotFound(_response);
            }
            _response.Result = categoria;
            _response.DisplayMessage = "Informacion del categoria";
            return Ok(_response);
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaDto categoriaDto)
        {
            try
            {
                CategoriaDto model = await _categoriaRepositorio.CreateUpdate(categoriaDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar la categoria";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(CategoriaDto categoriaDto)
        {
            try
            {
                CategoriaDto model = await _categoriaRepositorio.CreateUpdate(categoriaDto);
                _response.Result = model;
                return CreatedAtAction("GetCategoria", new { id = model.Id_categoria }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el categoria";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            try
            {
                bool estaeliminado = await _categoriaRepositorio.DeleteCategoria(id);
                if (estaeliminado)
                {
                    _response.Result = estaeliminado;
                    _response.DisplayMessage = "Cliente eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el categoria";
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
    }
}
