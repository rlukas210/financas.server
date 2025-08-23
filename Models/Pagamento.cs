namespace FinancasServer.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public int IdFatura { get; set; }

    public decimal Valor { get; set; }

    public DateOnly DataPagamento { get; set; }

    public string Status { get; set; }

    public DateTime DataCriacao { get; set; }

    public virtual Fatura IdFaturaNavigation { get; set; }
}
