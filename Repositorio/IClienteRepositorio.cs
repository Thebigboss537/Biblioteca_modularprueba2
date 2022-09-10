using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteDto>> GetClientes();
        Task<List<Programa_academicoDto>> GetProgramas_academicos();
        Task<ClienteDto> GetClienteById(int id);
        Task<ClienteDto> CreateUpdate(ClienteDto clienteDto);
        Task<bool> DeleteCliente(int id);
    }
}
