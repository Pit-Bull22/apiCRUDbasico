using EvoSystemWebAPI.Models;

namespace EvoSystemWebAPI.Repositorios.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<List<FuncionarioModel>> BuscarTodosFuncionarios();
        Task<FuncionarioModel> BuscarPorId(int id);
        Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario);
        Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, int id);
        Task<bool> Apagar(int id);

    }
}
