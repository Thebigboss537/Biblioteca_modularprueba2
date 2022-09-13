using Biblioteca_modular.Models;
using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioDto>> GetUsuarios();
        Task<List<Programa_academicoDto>> GetProgramas_academicos();
        Task<UsuarioDto> GetUsuarioById(int id);
        Task<UsuarioDto> CreateUpdate(UsuarioDto clienteDto);
        Task<bool> DeleteUsuario(int id);
    }
}
