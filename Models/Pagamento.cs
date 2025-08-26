namespace financas.server.Models
{
    public class Pagamento
{
    public int IdPagamento { get; set; }

    public decimal Valor { get; set; }

    public DateOnly DataPagamento { get; set; }

    public FormaPagamento FormaPagamento { get; set; }

    public StatusPagamento Status { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public string? Observacao { get; set; }

    public int? FaturaId { get; set; }
    public virtual Fatura? Fatura { get; set; }

    public int? TransacaoId { get; set; }
    public virtual Transacao? Transacao { get; set; }
}

public enum StatusPagamento
{
    Pendente,
    Pago,
    Parcial,
    Cancelado
}

}