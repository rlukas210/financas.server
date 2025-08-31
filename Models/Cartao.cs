using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
   public class Cartao
{
    [Key, Column("id_cartao")]
    public int IdCartao { get; set; }
    [Required, Column("nome_cartao"), MaxLength(100)]
    public string NomeCartao { get; set; }
    [Required, Column("bandeira"), MaxLength(100)]
    public string Bandeira { get; set; }
    [Required, Column("numero_cartao"), MinLength(4), MaxLength(4)]
    public string NumeroCartao { get; set; }  // apenas 4 dígitos
    [Required, Column("validade_cartao")]
    public DateOnly ValidadeCartao { get; set; }
    [Required, Column("limite"), Precision(10,2)]
    public decimal Limite { get; set; }
    [Column("status_cartao")]
    public StatusCartao Status { get; set; } = StatusCartao.Ativo;
    [Column("observacao"), MaxLength(255)]
    public string? Observacao { get; set; }
    [Column("id_usuario")]
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