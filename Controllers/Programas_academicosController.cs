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
    public class Programas_academicosController : ControllerBase
    {
        private readonly IPrograma_academicoRepositorio _programa_academicoRepositorio;
        protected ResponseDto _response;

        public Programas_academicosController(IPrograma_academicoRepositorio programa_academicoRepositorio)
        {
            _programa_academicoRepositorio = programa_academicoRepositorio;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programa_academico>>> GetPrograma_academicos()
        {
            try
            {
                var lista = await _programa_academicoRepositorio.GetProgramas_academicos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de programa_academicoes";
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Programa_academico>> GetPrograma_academico(int id)
        {
            var programa_academico = await _programa_academicoRepositorio.GetPrograma_academicoById(id);
            if (programa_academico == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Programa_academico no existe";
                return NotFound(_response);
            }
            _response.Result = programa_academico;
            _response.DisplayMessage = "Informacion del programa_academico";
            return Ok(_response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrograma_academico(int id, Programa_academicoDto programa_academicoDto)
        {
            try
            {
                Programa_academicoDto model = await _programa_academicoRepositorio.CreateUpdate(programa_academicoDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el programa_academico";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Programa_academico>> PostPrograma_academico(Programa_academicoDto programa_academicoDto)
        {
            try
            {
                Programa_academicoDto model = await _programa_academicoRepositorio.CreateUpdate(programa_academicoDto);
                _response.Result = model;
                return CreatedAtAction("GetPrograma_academico", new { id = model.Id_programa_academico }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el programa_academico";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrograma_academico(int id)
        {
            try
            {
                bool estaeliminado = await _programa_academicoRepositorio.DeletePrograma_academico(id);
                if (estaeliminado)
                {
                    _response.Result = estaeliminado;
                    _response.DisplayMessage = "Cliente eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el programa_academico";
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
