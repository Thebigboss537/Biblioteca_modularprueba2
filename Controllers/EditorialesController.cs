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
    public class EditorialesController : ControllerBase
    {
        private readonly IEditorialRepositorio _EditorialRepositorio;
        protected ResponseDto _response;

        public EditorialesController(IEditorialRepositorio EditorialRepositorio)
        {
            _EditorialRepositorio = EditorialRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Editoriales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editorial>>> GetEditoriales()
        {
            try
            {
                var lista = await _EditorialRepositorio.GetEditorial();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Editoriales";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/Editoriales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editorial>> GetEditorial(int id)
        {
            var Editorial = await _EditorialRepositorio.GetEditorialById(id);
            if (Editorial == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Editorial no existe";
                return NotFound(_response);
            }
            _response.Result = Editorial;
            _response.DisplayMessage = "Editorial";
            return Ok(_response);
        }


        // PUT: api/Editoriales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditorial(int id, EditorialDto EditorialDto)
        {
            try
            {
                EditorialDto model = await _EditorialRepositorio.CreateUpdate(EditorialDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el Registro";
                _response.ErrorMessages = new List<String> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Editoriales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Editorial>> PostEditorial(EditorialDto EditorialDto)
        {
            try
            {
                EditorialDto model = await _EditorialRepositorio.CreateUpdate(EditorialDto);
                _response.Result = model;
                return CreatedAtAction("GetEditorial", new { id = model.Id_editorial }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al grabar el Registro";
                _response.ErrorMessages = new List<String> { ex.ToString() };
                return BadRequest(_response);
            }


        }

        // DELETE: api/Editoriales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditorial(int id)
        {
            try
            {
                bool estaEliminado = await _EditorialRepositorio.DeleteEditorial(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Editorial Eliminada con Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar La Editorial ";
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
