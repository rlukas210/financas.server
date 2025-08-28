using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
#pragma warning disable CS8632
{
   public class Cartao
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCartao { get; set; }
    public string NomeCartao { get; set; }
    public string Bandeira { get; set; }
    public string Numero { get; set; }  // apenas 4 dígitos
    public DateOnly Validade { get; set; }
    public decimal Limite { get; set; }
    public StatusCartao Status { get; set; }
    public string? DescricaoStatus { get; set; }

    public virtual Usuario Usuario { get; set; }
    public virtual ICollection<Transacao> Transacoes { get; set; }
    public virtual ICollection<Fatura> Faturas { get; set; }
}

public enum StatusCartao
{
    Ativo,
    Bloqueado,
    Cancelado,
    Perdido
}

}