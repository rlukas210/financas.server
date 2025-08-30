using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
{
    [NotMapped]
    public class Boleto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // public int TransacaoId { get; set; }
        public virtual Transacao Transacao { get; set; }
        [Required, MaxLength(200)]
        public string Cedente { get; set; } // Quem emite
        [Required, MaxLength(200)]
        public string Sacado { get; set; }  // Quem paga
        [Required, MinLength(47), MaxLength(48)]
        public string LinhaDigitavel { get; set; }
        public string CodigoBarras { get; set; }

        public decimal ValorNominal { get; set; }
        public decimal? Juros { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Desconto { get; set; }

        public DateOnly Vencimento { get; set; }
        public string? PixCopiadoColado { get; set; } // Para boletos híbridos com PIX

        public string? NossoNumero { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Observacao { get; set; }
    }


}