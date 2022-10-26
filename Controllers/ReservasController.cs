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
using System.Security.Claims;

namespace Biblioteca_modular.Controllers
{
    [Route("api/reservas/")]
    [ApiController]
    [Authorize]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaRepositorio _reservaRepositorio;
        protected ResponseDto _response;

        public ReservasController(IReservaRepositorio reservaRepositorio)
        {
            _reservaRepositorio = reservaRepositorio;
            _response = new ResponseDto();
        }

        // GET: api/Reservaes
        [HttpGet("reservados")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservados()
        {
            try
            {
                var lista = await _reservaRepositorio.GetReservas();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de reservas";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet("reservadosid")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservadosid()
        {
            var id = User.Claims.Where(e => e.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            try
            {
                var lista = await _reservaRepositorio.GetReservadosid(Convert.ToInt32(id.FirstOrDefault().Value));
                _response.Result = lista;
                _response.DisplayMessage = "Lista de reservas";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/Reservaes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var reserva = await _reservaRepositorio.GetReservaById(id);
            if (reserva == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Reserva no existe";
                return NotFound(_response);
            }
            _response.Result = reserva;
            _response.DisplayMessage = "Informacion del reserva";
            return Ok(_response);
        }

        [HttpGet("cancelar/{id}")]
        public async Task<ActionResult<Reserva>> GetCancelar(int id)
        {
            var reserva = await _reservaRepositorio.Cancelarreserva(id);
            if (reserva == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Reserva no existe";
                return NotFound(_response);
            }
            _response.Result = reserva;
            _response.DisplayMessage = "Informacion del reserva";
            return Ok(_response);
        }

        [HttpGet("disponibles")]
        public async Task<ActionResult<IEnumerable<Material>>> Getdisponibles()
        {
            try
            {
                var lista = await _reservaRepositorio.GetDisponibles();
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

        

        // PUT: api/Reservaes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, ReservaDto reservaDto)
        {
            try
            {
                ReservaDto model = await _reservaRepositorio.CreateUpdate(reservaDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el reserva";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Reservaes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("crearreserva")]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaDto reservaDto)
        {
            try
            {
                var usuarioid = User.Claims.Where(e => e.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                reservaDto.Id_usuario = Convert.ToInt32(usuarioid.FirstOrDefault().Value);
                ReservaDto model = await _reservaRepositorio.CreateUpdate(reservaDto);
                _response.Result = model;
                return CreatedAtAction("GetReserva", new { id = model.Id_reserva }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el reserva";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Reservaes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            try
            {
                bool estaeliminado = await _reservaRepositorio.DeleteReserva(id);
                if (estaeliminado)
                {
                    _response.Result = estaeliminado;
                    _response.DisplayMessage = "reserva eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el reserva";
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
