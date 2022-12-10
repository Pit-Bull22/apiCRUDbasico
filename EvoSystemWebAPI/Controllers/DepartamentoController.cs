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
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepositorio _departamentoRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public DepartamentoController(IDepartamentoRepositorio departamentoRepositorio, IFuncionarioRepositorio funcionarioRepositorio)
        {
            _departamentoRepositorio = departamentoRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;   
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartamentoResponse>>> BuscarTodosDepartamentos()
        {
            List<DepartamentoModel> departamentos = await _departamentoRepositorio.BuscarTodosDepartamentos();

            List<DepartamentoResponse> departamentosResponse = new List<DepartamentoResponse>();

            departamentos.ForEach((departamento) => departamentosResponse.Add(new(departamento.Id, departamento.Nome, departamento.Sigla)));

            return Ok(departamentosResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoModel>> BuscarPorId(int id)
        {
            DepartamentoModel departamento = await _departamentoRepositorio.BuscarPorId(id);
           
            return Ok(departamento);
        }

        [HttpPost]
        public async Task<ActionResult<DepartamentoResponse>> Cadastrar([FromBody] DepartamentoRequest request)
        {
            DepartamentoModel departamentoModel = new(request.Nome, request.Sigla);

            DepartamentoModel departamento = await _departamentoRepositorio.Adicionar(departamentoModel);

            DepartamentoResponse departamentoResponse = new(departamento.Id, departamento.Nome, departamento.Sigla);

            return Ok(departamentoResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DepartamentoModel>> Atualizar([FromBody] DepartamentoModel departamentoModel, int id)
        {
            departamentoModel.Id = id;
            DepartamentoModel departamento = await _departamentoRepositorio.Atualizar(departamentoModel, id);
            return Ok(departamento);    
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartamentoModel>> Apagar(int id)
        {
            bool apagado = await _departamentoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
