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
    [Route("api/prestamos/")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamoRepositorio _prestamoRepositorio;
        protected ResponseDto _response;

        public PrestamosController(IPrestamoRepositorio prestamoRepositorio)
        {
            _prestamoRepositorio = prestamoRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Prestamoes
        [HttpGet("prestados")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamos()
        {
            try
            {
                var lista = await _prestamoRepositorio.GetPrestamos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de prestamos";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet("prestadosid")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamosid()
        {
            var id = User.Claims.Where(e => e.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            try
            {
                var lista = await _prestamoRepositorio.GetPrestadosid(Convert.ToInt32(id.FirstOrDefault().Value));
                _response.Result = lista;
                _response.DisplayMessage = "Lista de prestamos";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }
        
        // GET: api/Prestamoes/5
        [HttpGet("prestamo/{id}")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(int id)
        {
            var prestamo = await _prestamoRepositorio.GetPrestamoById(id);
            if (prestamo == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Prestamo no existe";
                return NotFound(_response);
            }
            _response.Result = prestamo;
            _response.DisplayMessage = "Informacion del prestamo";
            return Ok(_response);
        }

        [HttpGet("disponibles")]
        public async Task<ActionResult<IEnumerable<Material>>> Getdisponibles()
        {
            try
            {
                var lista = await _prestamoRepositorio.GetDisponibles();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Materiales disponibles para reservar";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // PUT: api/Prestamoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("prestamo/{id}")]
        public async Task<IActionResult> PutPrestamo(int id, PrestamoDto prestamoDto)
        {
            try
            {
                PrestamoDto model = await _prestamoRepositorio.CreateUpdate(prestamoDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el prestamo";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Prestamoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("crearprestamo")]
        public async Task<ActionResult<Prestamo>> PostPrestamo(PrestamoDto prestamoDto)
        {
            var usuario = await _prestamoRepositorio.ExistUsuario(prestamoDto);
            if (usuario == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "usuario no existe";
                return NotFound(_response);
            }
            try
            {
                PrestamoDto model = await _prestamoRepositorio.CreateUpdate(prestamoDto);
                _response.Result = model;
                return CreatedAtAction("GetPrestamo", new { id = model.Id_prestamo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el prestamo";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Prestamoes/5
        [HttpDelete("prestamo/{id}")]
        public async Task<IActionResult> DeletePrestamo(int id)
        {
            try
            {
                bool estaeliminado = await _prestamoRepositorio.DeletePrestamo(id);
                if (estaeliminado)
                {
                    _response.Result = estaeliminado;
                    _response.DisplayMessage = "prestamo eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el prestamo";
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
