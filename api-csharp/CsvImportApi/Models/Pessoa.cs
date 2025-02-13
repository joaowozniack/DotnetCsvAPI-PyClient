using System.ComponentModel.DataAnnotations;

namespace CsvImportApi.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Cidade { get; set; } = string.Empty;
        public string Profissao { get; set; } = string.Empty;
    }
}
