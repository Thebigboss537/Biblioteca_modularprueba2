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
using Microsoft.AspNetCore.Authorization;

namespace Biblioteca_modular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1, 4")]
    public class SedesController : ControllerBase
    {
        private readonly ISedeRepositorio _SedeRepositorio;
        protected ResponseDto _response;

        public SedesController(ISedeRepositorio SedeRepositorio)
        {
            _SedeRepositorio = SedeRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Sedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSedes()
        {
            try
            {
                var lista = await _SedeRepositorio.GetSede();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Sedes";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/Sede/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sede>> GetSede(int id)
        {
            var Sede = await _SedeRepositorio.GetSedeById(id);
            if (Sede == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Sede no existe";
                return NotFound(_response);
            }
            _response.Result = Sede;
            _response.DisplayMessage = "Sede";
            return Ok(_response);
        }


        // PUT: api/Sedes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSede(int id, SedeDto SedeDto)
        {
            try
            {
                SedeDto model = await _SedeRepositorio.CreateUpdate(SedeDto);
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

        // POST: api/Sedes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sede>> PostSede(SedeDto SedeDto)
        {
            try
            {
                SedeDto model = await _SedeRepositorio.CreateUpdate(SedeDto);
                _response.Result = model;
                return CreatedAtAction("GetSede", new { id = model.Id_sede }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al grabar el Registro";
                _response.ErrorMessages = new List<String> { ex.ToString() };
                return BadRequest(_response);
            }


        }

        // DELETE: api/Sedes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSede(int id)
        {
            try
            {
                bool estaEliminado = await _SedeRepositorio.DeleteSede(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Sede Eliminada con Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar La Sede ";
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