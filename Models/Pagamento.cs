using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
    public class Pagamento
{
    [Key]
    public int IdPagamento { get; set; }

    [Required, Precision(10,2)]
    public decimal Valor { get; set; }
    [Required]
    public DateOnly DataPagamento { get; set; }
   // [Required]
    public FormaPagamento FormaPagamento { get; set; }

    public StatusPagamento Status { get; set; } = StatusPagamento.Pendente;

    public DateTime DataCriacao { get; set; } = DateTime.Now;
    [MaxLength(200)]
    public string? Observacao { get; set; }

    public virtual Fatura? Fatura { get; set; }

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