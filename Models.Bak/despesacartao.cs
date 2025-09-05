using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancasServer.Models;

[Index("categoria", Name = "categoria")]
[Index("idCartao", Name = "idCartao")]
[Index("usuarioInclusao", Name = "usuarioInclusao")]
public partial class despesacartao
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int idDespesa { get; set; }

    [Column(TypeName = "int(11)")]
    public int idCartao { get; set; }

    [Required]
    [Column(TypeName = "enum('credito','debito')")]
    public string natureza { get; set; }

    [Precision(10, 2)]
    public decimal valor { get; set; }

    public DateOnly data { get; set; }

    [Column(TypeName = "int(11)")]
    public int parcelaAtual { get; set; }

    [Column(TypeName = "int(11)")]
    public int parcelaTotal { get; set; }

    [Column(TypeName = "int(11)")]
    public int categoria { get; set; }

    [Column(TypeName = "enum('pendente','paga','cancelada')")]
    public string status { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime data_criacao { get; set; }

    [StringLength(255)]
    public string observacao { get; set; }

    [Column(TypeName = "int(11)")]
    public int usuarioInclusao { get; set; }

    [ForeignKey("categoria")]
    [InverseProperty("despesacartao")]
    public virtual categorias categoriaNavigation { get; set; }

    [InverseProperty("idDespesaNavigation")]
    public virtual ICollection<divisaotransacao> divisaotransacao { get; set; } = new List<divisaotransacao>();

    [ForeignKey("idCartao")]
    [InverseProperty("despesacartao")]
    public virtual cartoes idCartaoNavigation { get; set; }

    [ForeignKey("usuarioInclusao")]
    [InverseProperty("despesacartao")]
    public virtual usuario usuarioInclusaoNavigation { get; set; }
}
