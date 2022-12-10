using EvoSystemWebAPI.Data;
using EvoSystemWebAPI.Models;
using EvoSystemWebAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EvoSystemWebAPI.Repositorios
{
    public class DepartamentoRepositorio : IDepartamentoRepositorio
    {
        private readonly DepartamentoContext _dbContext;
        public DepartamentoRepositorio(DepartamentoContext departamentoContext)
        {
            _dbContext = departamentoContext;
        }

        public async Task<DepartamentoModel> BuscarPorId(int id)
        {
            return await _dbContext.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<DepartamentoModel>> BuscarTodosDepartamentos()
        {
            return await _dbContext.Departamentos.ToListAsync();
        }
        public async Task<DepartamentoModel> Adicionar(DepartamentoModel departamento)
        {
            await _dbContext.Departamentos.AddAsync(departamento);
            await _dbContext.SaveChangesAsync();

            return departamento;
        }

        public async Task<DepartamentoModel> Atualizar(DepartamentoModel departamento, int id)
        {
            DepartamentoModel departamentoPorId = await BuscarPorId(id);

            if(departamentoPorId == null)
            {
                throw new Exception($"Departamento para o ID: {id} não foi encontrado no banco de dados.");
            }

            departamentoPorId.Nome = departamento.Nome;
            departamentoPorId.Sigla = departamento.Sigla;

            _dbContext.Departamentos.Update(departamentoPorId);
            await _dbContext.SaveChangesAsync();

            return departamentoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            DepartamentoModel departamentoPorId = await BuscarPorId(id);

            if (departamentoPorId == null)
            {
                throw new Exception($"Departamento para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Departamentos.Remove(departamentoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
            
        }



    }
}
