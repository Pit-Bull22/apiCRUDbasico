namespace EvoSystemWebAPI.Models.Request
{
    public class FuncionarioRequest
    {
        public FuncionarioRequest(string? nome, string? foto, int rg, int departamentoId)
        {
            Nome = nome;
            Foto = foto;
            Rg = rg;
            DepartamentoId = departamentoId;
        }

        public string? Nome { get; set; }
        public string? Foto { get; set; }
        public int Rg { get; set; }
        public int DepartamentoId { get; set; }
    }
}
