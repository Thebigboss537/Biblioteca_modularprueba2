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
using Biblioteca_modular.Util;

namespace Biblioteca_modular.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        protected ResponseDto _response;

        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _response = new ResponseDto();
        }

        [HttpGet("clientes")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            try
            {
                var lista = await _clienteRepositorio.GetClientes();
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

        [HttpGet("cliente/{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clienteRepositorio.GetClienteById(id);
            if (cliente == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Cliente no existe";
                return NotFound(_response);
            }
            _response.Result = cliente;
            _response.DisplayMessage = "Informacion del cliente";
            return Ok(_response);
        }


        [HttpPut("editarcliente/{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDto clienteDto)
        {
            try
            {

                ClienteDto model = await _clienteRepositorio.CreateUpdate(clienteDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el cliente";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        [HttpDelete("eliminarcliente/{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                bool estaeliminado = await _clienteRepositorio.DeleteCliente(id);
                if (estaeliminado)
                {
                    _response.Result = estaeliminado;
                    _response.DisplayMessage = "cliente eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el cliente";
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

        [HttpGet("crear")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Dropdownlist()
        {
            try
            {
                gets dropdowns = new()
                {
                    Programas_academicos = await _clienteRepositorio.GetProgramas_academicos()
            };
                _response.Result = dropdowns;
                _response.DisplayMessage = "drop down list";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpPost("crear")]
        public async Task<IActionResult> Crearcliente(ClienteDto usuario)
        {
            try
            {
                ClienteDto model = await _clienteRepositorio.CreateUpdate(usuario);
                _response.Result = model;
                return CreatedAtAction("GetCliente", new { id = model.Id_cliente }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el cliente";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        /*[HttpPost("crearusuario")]
        public async Task<IActionResult> crearusuario(UsuarioDto usuario)
        {
            var respuesta = await _usuarioRepositorio.Register(
                new Usuario
                {
                    Cedula = usuario.Cedula,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Id_programa_academico = usuario.Id_programa_academico,
                    Telefono = usuario.Telefono,
                    Semestre = usuario.Semestre,
                    Correo_electronico = usuario.Correo_electronico,
                    Estado = Util.Estado.Inactivo
                }, usuario.Contraseña);
            if (respuesta == "existe")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Login_usuario ya existe";
                return BadRequest(_response);
            }

            if (respuesta == "error")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al crear el usuario";
                return BadRequest(_response);
            }

            JwTPackage jpt = new JwTPackage();
            jpt.UserName = usuario.Cedula.ToString();
            jpt.Token = respuesta;
            _response.Result = jpt;
            _response.DisplayMessage = "Usuario creado con exito";
            //_response.Result = respuesta;
            

            return Ok(_response);
        }

        [HttpGet("crearusuario")]
        public async Task<ActionResult<Usuario>> GetProgramas_academicos()
        {
            try
            {
                gets get = new gets();
                get.programa = await _usuarioRepositorio.GetProgramas_academicos();
                get.rol = await _usuarioRepositorio.GetRoles();
                get.estado = (Estado[])Enum.GetValues(typeof(Estado));

                var lista = await _usuarioRepositorio.GetProgramas_academicos();

                _response.Result = get;
                _response.DisplayMessage = "Lista de programas academicos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }*/

        public class JwTPackage
        {
            public string UserName { get; set; }
            public string Token { get; set; }
        }

        public class gets
        {

            public List<Programa_academicoDto> Programas_academicos { get; set; }
        }
    }
}
