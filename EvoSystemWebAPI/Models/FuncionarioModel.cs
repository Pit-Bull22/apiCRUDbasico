namespace EvoSystemWebAPI.Models
{
    public class FuncionarioModel
    {
        public FuncionarioModel(string? nome, string? foto, int rg, int departamentoId)
        {
            Nome = nome;
            Foto = foto;
            Rg = rg;
            DepartamentoId = departamentoId;
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Foto { get; set; }
        public int Rg { get; set; }
        public virtual DepartamentoModel? Departamento { get; set; }
        public int DepartamentoId { get; set; }
    }
}
