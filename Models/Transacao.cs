using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
   public class Transacao
{
    [Key]
    public int IdTransacao { get; set; }
    [Required, MaxLength(100)]
    public string NomeTransacao { get; set; }
    [Required, Precision(10,2)]
    public decimal Valor { get; set; }
    [Required]
    public DateOnly Data { get; set; }
    [Required]
    public TipoTransacao TipoTransacao { get; set; }
    public FormaPagamento FormaPagamento { get; set; }
    public int? ParcelaAtual { get; set; }
    public int? ParcelaTotal { get; set; }
    public virtual Cartao? Cartao { get; set; }
    public virtual Categoria? Categoria { get; set; }
    public StatusTransacao Status { get; set; } = StatusTransacao.Pendente;
    public string? Observacao { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public virtual Usuario Dono { get; set; }

    public int? FaturaId { get; set; }
    public virtual Fatura? Fatura { get; set; }
    public virtual Boleto? Boleto { get; set; }
    public virtual ICollection<DivisaoTransacao> Divisoes { get; set; }
}

public enum TipoTransacao
{
    Cartao,
    Dinheiro,
    Boleto,
    Pessoa
}

public enum FormaPagamento
{
    Cartao,
    Dinheiro,
    Pix,
    Transferencia,
    Boleto,
    Outro
}

public enum StatusTransacao
{
    Pendente,
    Paga,
    Cancelada
}

}