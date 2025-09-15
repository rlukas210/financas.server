using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
  public class Cartao
  {
    [Key]
    public Guid IdCartao { get; set; }
    [Required, MaxLength(100)]
    public string NomeCartao { get; set; }
    [Required, StringLength(4, MinimumLength = 4)]
    public string NumeroCartao { get; set; }
    [Required, MaxLength(50)]
    public string BandeiraCartao { get; set; }
    [Required]
    public DateOnly ValidadeCartao { get; set; }
    [Required, Precision(18, 2)]
    public decimal LimiteCartao { get; set; }
   // public StatusCartao Status { get; set; } = StatusCartao.Ativo;
    [Required]
    public Usuarios DonoCartao { get; set; }
    [MaxLength(128)]
    public string? Observacoes { get; set; }
  }
  public enum StatusCartao
  {
    //[Display(Name = "ativo")]
    Ativo,
    //[Display(Name = "inativo")]
    Inativo
  }
}