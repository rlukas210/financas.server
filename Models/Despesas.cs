using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
{
    public class Despesas
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDespesa { get; set; }
        [Required]
        public string NomeDespesa { get; set; }
        // TODO: Dinheiro, boleto, outros? 
        // public string TipoDespesa { get; set; }
        [Required]
        public decimal ValorDespesa { get; set; }
        [Required]
        public DateTime DataDespesa { get; set; }
        public string? Descricao { get; set; }
        public Cartao Cartao { get; set; }
        
    }
}