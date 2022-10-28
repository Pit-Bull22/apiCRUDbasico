namespace EvoSystemWebAPI.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Foto { get; set; }
        public int Rg { get; set; }
        public DepartamentoModel? Departamento { get; set; }
        public int DepartamentoId { get; set; }
    }
}
