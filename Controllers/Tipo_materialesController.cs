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
    public class Tipo_materialesController : ControllerBase
    {
        private readonly ITipo_materialRepositorio _Tipo_materialRepositorio;
        protected ResponseDto _response;

        public Tipo_materialesController(ITipo_materialRepositorio Tipo_materialRepositorio)
        {
            _Tipo_materialRepositorio = Tipo_materialRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Tipo_materiales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo_material>>> GetTipos_materiales()
        {
            try
            {
                var lista = await _Tipo_materialRepositorio.GetTipo_material();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de clientes";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/Tipo_materiales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo_material>> GetTipo_material(int id)
        {
            var Tipo_material = await _Tipo_materialRepositorio.GetTipo_materialById(id);
            if(Tipo_material == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Tipo de Material no existe";
                return NotFound(_response);
            }
            _response.Result = Tipo_material;
            _response.DisplayMessage = "Tipo Material";
            return Ok(_response);
        }

        // PUT: api/Tipo_materiales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo_material(int id, Tipo_materialDto tipo_materialDto)
        {
            try
            {
                Tipo_materialDto model = await _Tipo_materialRepositorio.CreateUpdate(tipo_materialDto);
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

        // POST: api/Tipo_materiales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tipo_material>> PostTipo_material(Tipo_materialDto tipo_materialDto)
        {
            try
            {
                Tipo_materialDto model = await _Tipo_materialRepositorio.CreateUpdate(tipo_materialDto);
                _response.Result = model;
                return CreatedAtAction("GetTipo_material", new { id = model.Id_tipo_material }, _response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al grabar el Registro";
                _response.ErrorMessages = new List<String> { ex.ToString() };
                return BadRequest(_response);
            }

           
        }

        // DELETE: api/Tipo_materiales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo_material(int id)
        {
            try
            {
                bool estaEliminado = await _Tipo_materialRepositorio.DeleteTipo_material(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Tipo de material Eliminado con Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el Tipo de material ";
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
