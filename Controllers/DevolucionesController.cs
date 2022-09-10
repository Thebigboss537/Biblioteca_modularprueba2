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
    public class DevolucionesController : ControllerBase
    {
        private readonly IDevolucionRepositorio _devolucionRepositorio;
        protected ResponseDto _response;

        public DevolucionesController(IDevolucionRepositorio devolucionRepositorio)
        {
            _devolucionRepositorio = devolucionRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Devoluciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devolucion>>> GetDevoluciones()
        {
            try
            {
                var lista = await _devolucionRepositorio.GetDevoluciones();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de devolucions";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/Devoluciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devolucion>> GetDevolucion(int id)
        {
            var devolucion = await _devolucionRepositorio.GetDevolucionById(id);
            if (devolucion == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Devolucion no existe";
                return NotFound(_response);
            }
            _response.Result = devolucion;
            _response.DisplayMessage = "Informacion del devolucion";
            return Ok(_response);
        }

        // PUT: api/Devoluciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevolucion(int id, DevolucionDto devolucionDto)
        {
            try
            {
                DevolucionDto model = await _devolucionRepositorio.CreateUpdate(devolucionDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el devolucion";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Devoluciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Devolucion>> PostDevolucion(DevolucionDto devolucionDto)
        {
            try
            {
                DevolucionDto model = await _devolucionRepositorio.CreateUpdate(devolucionDto);
                _response.Result = model;
                return CreatedAtAction("GetDevolucion", new { id = model.Id_devolucion }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el devolucion";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Devoluciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevolucion(int id)
        {
            try
            {
                bool estaeliminado = await _devolucionRepositorio.DeleteDevolucion(id);
                if (estaeliminado)
                {
                    _response.Result = estaeliminado;
                    _response.DisplayMessage = "devolucion eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el devolucion";
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
