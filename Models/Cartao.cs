using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
   public class Cartao
{
    [Key]
    public int IdCartao { get; set; }
    [Required, MaxLength(100)]
    public string NomeCartao { get; set; }
    [Required, MaxLength(100)]
    public string Bandeira { get; set; }
    [Required, MinLength(4), MaxLength(4)]
    public string NumeroCartao { get; set; }  // apenas 4 dígitos
    [Required]
    public DateOnly ValidadeCartao { get; set; }
    [Required, Precision(10,2)]
    public decimal Limite { get; set; }
    public StatusCartao Status { get; set; } = StatusCartao.Ativo;
    public string? Observacao { get; set; }

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