using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<List<UsuarioDto>> GetClientes();
        Task<List<Programa_academicoDto>> GetProgramas_academicos();
        Task<UsuarioDto> GetClienteById(int id);
        Task<UsuarioDto> CreateUpdate(UsuarioDto clienteDto);
        Task<bool> DeleteCliente(int id);
    }
}
