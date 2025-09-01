using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancasServer.Models;

[Index("idUsuario", Name = "idUsuario")]
public partial class cartoes
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int idCartao { get; set; }

    [Required]
    [StringLength(100)]
    public string nomeCartao { get; set; }

    [Required]
    [StringLength(50)]
    public string bandeiraCartao { get; set; }

    [Required]
    [Column(TypeName = "enum('credito','debito','ambos')")]
    public string tipoCartao { get; set; }

    [Required]
    [StringLength(4)]
    public string numeroCartao { get; set; }

    public DateOnly validadeCartao { get; set; }

    [Precision(10, 2)]
    public decimal limiteCartao { get; set; }

    [Column(TypeName = "enum('ativo','bloqueado','cancelado','perdido')")]
    public string statusCartao { get; set; }

    [StringLength(255)]
    public string observacaoCartao { get; set; }

    [Column(TypeName = "int(11)")]
    public int idUsuario { get; set; }

    [InverseProperty("idCartaoNavigation")]
    public virtual ICollection<despesacartao> despesacartao { get; set; } = new List<despesacartao>();

    [InverseProperty("idCartaoNavigation")]
    public virtual ICollection<faturas> faturas { get; set; } = new List<faturas>();

    [ForeignKey("idUsuario")]
    [InverseProperty("cartoes")]
    public virtual usuario idUsuarioNavigation { get; set; }
}
