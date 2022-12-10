using System.ComponentModel.DataAnnotations.Schema;

namespace EvoSystemWebAPI.Models
{
    public class DepartamentoModel
    {
        public DepartamentoModel(string nome ,string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sigla { get; set; }
    

    }
}