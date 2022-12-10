namespace EvoSystemWebAPI.Models.Response
{
    public class FuncionarioResponse
    {
        public FuncionarioResponse(string? nome, string? foto, int rg, DepartamentoResponse? departamento)
        {
            Nome = nome;
            Foto = foto;
            Rg = rg;
            Departamento = departamento;
        }

        public string? Nome { get; set; }
        public string? Foto { get; set; }
        public int Rg { get; set; }
        public DepartamentoResponse? Departamento { get; set; }
    }
}
