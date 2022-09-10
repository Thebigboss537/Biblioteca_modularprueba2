using Biblioteca_modular.Models.Dto;

namespace Biblioteca_modular.Repositorio
{
    public interface IPrograma_academicoRepositorio
    {
        Task<List<Programa_academicoDto>> GetProgramas_academicos();
        Task<Programa_academicoDto> GetPrograma_academicoById(int id);
        Task<Programa_academicoDto> CreateUpdate(Programa_academicoDto programa_academicoDto);
        Task<bool> DeletePrograma_academico(int id);
    }
}
