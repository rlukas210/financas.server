using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancasServer.Models;

[Index("donoId", Name = "donoId")]
[Index("faturaId", Name = "faturaId")]
public partial class transacoes
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int idTransacao { get; set; }

    [Required]
    [StringLength(100)]
    public string nomeTransacao { get; set; }

    [Precision(10, 2)]
    public decimal valorTransacao { get; set; }

    public DateOnly dataTransacao { get; set; }

    [Column(TypeName = "int(11)")]
    public int idCartao { get; set; }

    [Column(TypeName = "int(11)")]
    public int idCategoria { get; set; }

    [Column(TypeName = "enum('pendente','paga','cancelada')")]
    public string statusTransacao { get; set; }

    [StringLength(255)]
    public string observacaoTransacao { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime dataLancamento { get; set; }

    [Column(TypeName = "int(11)")]
    public int donoId { get; set; }

    [Column(TypeName = "int(11)")]
    public int faturaId { get; set; }

    [ForeignKey("donoId")]
    [InverseProperty("transacoes")]
    public virtual usuario dono { get; set; }

    [ForeignKey("faturaId")]
    [InverseProperty("transacoes")]
    public virtual faturas fatura { get; set; }
}
