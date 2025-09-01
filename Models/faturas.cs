using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancasServer.Models;

[Index("idCartao", Name = "idCartao")]
[Index("idUsuario", Name = "idUsuario")]
public partial class faturas
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int idFatura { get; set; }

    [Column(TypeName = "int(11)")]
    public int idUsuario { get; set; }

    [Column(TypeName = "int(11)")]
    public int idCartao { get; set; }

    public DateOnly dataReferencia { get; set; }

    [Precision(10, 2)]
    public decimal valorTotal { get; set; }

    [Column(TypeName = "enum('pendente','paga','cancelada')")]
    public string statusFatura { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime dataCriacao { get; set; }

    [ForeignKey("idCartao")]
    [InverseProperty("faturas")]
    public virtual cartoes idCartaoNavigation { get; set; }

    [ForeignKey("idUsuario")]
    [InverseProperty("faturas")]
    public virtual usuario idUsuarioNavigation { get; set; }

    [InverseProperty("fatura")]
    public virtual ICollection<transacoes> transacoes { get; set; } = new List<transacoes>();
}
