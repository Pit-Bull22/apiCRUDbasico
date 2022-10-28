using EvoSystemWebAPI.Data;
using EvoSystemWebAPI.Models;
using EvoSystemWebAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EvoSystemWebAPI.Repositorios
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly DepartamentoContext _dbcontext;
        public FuncionarioRepositorio(DepartamentoContext departamentoContext)
        {
            _dbcontext = departamentoContext;
        }
        public async Task<FuncionarioModel> BuscarPorId(int id)
        {
            return await _dbcontext.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FuncionarioModel>> BuscarTodosFuncionarios()
        {
            return await _dbcontext.Funcionarios.ToListAsync();
        }
        public async Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario)
        {
            await _dbcontext.Funcionarios.AddAsync(funcionario);
            await _dbcontext.SaveChangesAsync();

            return funcionario;
        }

        public async Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, int id)
        {
            FuncionarioModel funcionarioPorId = await BuscarPorId(id);

            if (funcionarioPorId == null)
            {
                throw new Exception($"Funcionario para o ID: {id} não foi encontrado no banco de dados.");
            }

            funcionarioPorId.Nome = funcionario.Nome;
            funcionarioPorId.Rg = funcionario.Rg;
            funcionarioPorId.Foto = funcionario.Foto;

            _dbcontext.Funcionarios.Update(funcionarioPorId);
            await _dbcontext.SaveChangesAsync();

            return funcionarioPorId;
        }    

        public async Task<bool> Apagar(int id)
        {
            FuncionarioModel funcionarioPorId = await BuscarPorId(id);      

            if (funcionarioPorId == null) 
            {
                throw new Exception($"Funcionario para o ID: {id} não foi encontrado no banco de dados.");
            }

                _dbcontext.Funcionarios.Remove(funcionarioPorId);
                await _dbcontext.SaveChangesAsync();
                 return true;
        }


    }
}
