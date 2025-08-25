using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancasServer.Models;

[Table("Cartoes")]
public class Cartao
{
    [Column("idCartao")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCartao { get; set; }

    [Required]
    [Column("nomeCartao"), MaxLength(50)]
    public string NomeCartao { get; set; }

    [Required]
    [Column("bandeira"), MaxLength(50)]
    public string Bandeira { get; set; }

    //TODO: ???
    // IdUsuario está referenciando o que?
    [ForeignKey("IdUsuario")]
    [Column("idUsuario")]
    public int IdUsuario { get; set; }
    public Usuario Usuario { get; set; }

    [Column("numero"), MaxLength(4)]
    public string Numero { get; set; }

    [Column("validade")]
    public DateOnly Validade { get; set; }

    [Column("limite")]
    public decimal Limite { get; set; }

    [Column("status")]
    public string Status { get; set; }

    [Column("descricaoStatus"), MaxLength(50)]
    public string DescricaoStatus { get; set; }

    public virtual ICollection<Fatura> Faturas { get; set; } = new List<Fatura>();

    public virtual Usuario IdUsuarioNavigation { get; set; }

    public virtual ICollection<TransacaoCartao> TransacaoCartoes { get; set; } = new List<TransacaoCartao>();
}

public enum StatusCartao
{
    Ativo,
    Bloqueado,
    Cancelado
}