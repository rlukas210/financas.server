using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
#pragma warning disable CS8632
{
   public class Transacao
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTransacao { get; set; }

    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public DateOnly Data { get; set; }

    public TipoTransacao TipoTransacao { get; set; }
    public FormaPagamento FormaPagamento { get; set; }

    public int? ParcelaAtual { get; set; }
    public int? ParcelaTotal { get; set; }

    public int? IdCartao { get; set; }
    public virtual Cartao? Cartao { get; set; }

    public int? CategoriaId { get; set; }
    public virtual Categoria? Categoria { get; set; }

    public StatusTransacao Status { get; set; }
    public string? Observacao { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public Guid UsuarioInclusao { get; set; }
    public virtual Usuario Usuario { get; set; }

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