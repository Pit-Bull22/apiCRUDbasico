namespace EvoSystemWebAPI.Models.Response
{
    public class DepartamentoResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string SiglaNome
        {
            get
            {
                return GetSiglaNome();
            }
        }

        public DepartamentoResponse(int id, string nome, string sigla)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
        }

        private string GetSiglaNome()
        {
            return $"Sigla: {Sigla} - Nome: {Nome}";
        }
    }
}
