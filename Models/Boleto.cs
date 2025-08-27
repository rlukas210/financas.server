namespace financas.server.Models
{
    public class Boleto
    {
        public int Id { get; set; }

        public int TransacaoId { get; set; }
        public virtual Transacao Transacao { get; set; }

        public string Cedente { get; set; } // Quem emite
        public string Sacado { get; set; }  // Quem paga

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