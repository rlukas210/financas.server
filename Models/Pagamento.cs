using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
    public class Pagamento
{
    [Key, Column("id_pagamento")]
    public int IdPagamento { get; set; }

    [Required, Column("valor"), Precision(10,2)]
    public decimal Valor { get; set; }
    [Required, Column("data_pagamento")]
    public DateOnly DataPagamento { get; set; }
    [Required, Column("forma_pagamento")]
    public FormaPagamento FormaPagamento { get; set; }
    [Column("status_pagamento")]
    public StatusPagamento Status { get; set; } = StatusPagamento.Pendente;
    [Column("data_criacao")]
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    [Column("observacao"), MaxLength(200)]
    public string? Observacao { get; set; }
    [Column("fatura_id")]
    public int? FaturaId { get; set; }
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