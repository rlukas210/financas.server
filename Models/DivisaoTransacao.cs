using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancasServer.Models;

[Index("donoDespesa", Name = "donoDespesa")]
[Index("idDespesa", Name = "idDespesa")]
public partial class divisaotransacao
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int idDivisao { get; set; }

    [Column(TypeName = "int(11)")]
    public int idDespesa { get; set; }

    [Column(TypeName = "int(11)")]
    public int donoDespesa { get; set; }

    [Precision(10, 2)]
    public decimal valor { get; set; }

    [Column(TypeName = "enum('pendente','pago','cancelado')")]
    public string status { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime data_criacao { get; set; }

    [ForeignKey("donoDespesa")]
    [InverseProperty("divisaotransacao")]
    public virtual usuario donoDespesaNavigation { get; set; }

    [ForeignKey("idDespesa")]
    [InverseProperty("divisaotransacao")]
    public virtual despesacartao idDespesaNavigation { get; set; }
}
