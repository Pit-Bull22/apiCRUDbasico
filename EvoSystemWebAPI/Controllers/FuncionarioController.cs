using EvoSystemWebAPI.Models;
using EvoSystemWebAPI.Models.Request;
using EvoSystemWebAPI.Models.Response;
using EvoSystemWebAPI.Repositorios;
using EvoSystemWebAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvoSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;
        private readonly IDepartamentoRepositorio _departamentoRepositorio;
        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio, IDepartamentoRepositorio departamentoRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
            _departamentoRepositorio = departamentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<FuncionarioModel>>> BuscarTodosFuncionarios()
        {
            List<FuncionarioModel> funcionarios = await _funcionarioRepositorio.BuscarTodosFuncionarios();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<FuncionarioModel>>> BuscarPorid(int id)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.BuscarPorId(id);
            return Ok(funcionario);
        }

        [HttpGet("Departamento/{depId}")]
        public async Task<ActionResult<List<FuncionarioModel>>> BuscarPorDepartamento(int depId)
        {
            List<FuncionarioModel> funcionarios = await _funcionarioRepositorio.BuscarPorDepartamento(depId);
            return Ok(funcionarios);
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioResponse>> Cadastrar([FromBody] FuncionarioRequest request)
        {
            FuncionarioModel funcionarioModel = new(request.Nome, request.Foto, request.Rg, request.DepartamentoId);

            FuncionarioModel funcionario = await _funcionarioRepositorio.Adicionar(funcionarioModel);

            var departamentoModel = await _departamentoRepositorio.BuscarPorId(funcionario.DepartamentoId);

            DepartamentoResponse departamentoResponse = new(departamentoModel.Id, departamentoModel.Nome, departamentoModel.Sigla);

            FuncionarioResponse funcionarioResponse = new(funcionario.Nome, funcionario.Foto, funcionario.Rg, departamentoResponse);

            return Ok(funcionarioResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FuncionarioModel>> Atualizar([FromBody] FuncionarioModel funcionarioModel, int id) 
        {
            funcionarioModel.Id = id;
            FuncionarioModel funcionario = await _funcionarioRepositorio.Atualizar(funcionarioModel, id);
            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FuncionarioModel>> Apagar(int id)
        {
            bool apagado = await _funcionarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
