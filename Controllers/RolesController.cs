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
    public class RolesController : ControllerBase
    {
        private readonly IRolRepositorio _rolRepositorio;
        protected ResponseDto _response;

        public RolesController(IRolRepositorio rolRepositorio)
        {
            _rolRepositorio = rolRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            try
            {
                var lista = await _rolRepositorio.GetRoles();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de roles";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _rolRepositorio.GetRolById(id);
            if (rol == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Rol no existe";
                return NotFound(_response);
            }
            _response.Result = rol;
            _response.DisplayMessage = "Informacion del rol";
            return Ok(_response);
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, RolDto rolDto)
        {
            try
            {
                RolDto model = await _rolRepositorio.CreateUpdate(rolDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el rol";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(RolDto rolDto)
        {
            try
            {
                RolDto model = await _rolRepositorio.CreateUpdate(rolDto);
                _response.Result = model;
                return CreatedAtAction("GetRol", new { id = model.Id_rol }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el rol";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            try
            {
                bool estaeliminado = await _rolRepositorio.DeleteRol(id);
                if (estaeliminado)
                {
                    _response.Result = estaeliminado;
                    _response.DisplayMessage = "Rol eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el rol";
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
