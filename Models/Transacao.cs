using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
   public class Transacao
{
    [Key, Column("id_transacao")]
    public int IdTransacao { get; set; }
    [Required, Column("nome_transacao"), MaxLength(100)]
    public string NomeTransacao { get; set; }
    [Required, Column("valor"), Precision(10,2)]
    public decimal Valor { get; set; }
    [Required, Column("data")]
    public DateOnly Data { get; set; }
    [Required, Column("tipo_transacao")]
    public TipoTransacao TipoTransacao { get; set; }
    public FormaPagamento FormaPagamento { get; set; }
    [Column("parcela_atual")]
    public int? ParcelaAtual { get; set; }
    [Column("parcela_total")]
    public int? ParcelaTotal { get; set; }
    [Column("cartao_id")]
    public virtual Cartao? Cartao { get; set; }
    [Column("categoria_id")]
    public virtual Categoria? Categoria { get; set; }
    [Column("status_transacao")]
    public StatusTransacao Status { get; set; } = StatusTransacao.Pendente;
    [Column("observacao")]
    public string? Observacao { get; set; }
    [Column("data_criacao")]
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    [Column("id_usuario")]
    public virtual Usuario Dono { get; set; }
    [Column("id_fatura")]
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