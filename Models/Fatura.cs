namespace financas.server.Models
{
   public class Fatura
{
    public int IdFatura { get; set; }

    public int IdUsuario { get; set; }
 //   public virtual Usuario Usuario { get; set; }

    public int IdCartao { get; set; }
    public virtual Cartao Cartao { get; set; }

    public int Mes { get; set; }
    public int Ano { get; set; }

    public decimal ValorTotal { get; set; }

    public StatusFatura Status { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public string? Observacao { get; set; }

    public int UsuarioInclusao { get; set; }
    public virtual Usuario UsuarioInclusaoNavigation { get; set; }

    public virtual ICollection<Transacao> Transacoes { get; set; }
    public virtual ICollection<Pagamento> Pagamentos { get; set; }
}

public enum StatusFatura
{
    Pendente,
    Paga,
    Cancelada
}

}