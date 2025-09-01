using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancasServer.Models;

[Index("donoBoleto", Name = "donoBoleto")]
[Index("usuarioInclusao", Name = "usuarioInclusao")]
public partial class boletos
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int idBoleto { get; set; }

    [Required]
    [StringLength(255)]
    public string nomeBoleto { get; set; }

    [Column(TypeName = "int(11)")]
    public int donoBoleto { get; set; }

    [StringLength(128)]
    public string cedenteBoleto { get; set; }

    [StringLength(128)]
    public string sacadoBoleto { get; set; }

    [StringLength(48)]
    public string codigoBoleto { get; set; }

    [Precision(10, 2)]
    public decimal valorNominal { get; set; }

    [Precision(10, 2)]
    public decimal? jurosBoleto { get; set; }

    [Precision(10, 2)]
    public decimal? multaBoleto { get; set; }

    [Precision(10, 2)]
    public decimal? descontoBoleto { get; set; }

    public string qrCodePix { get; set; }

    public DateOnly dataVencimento { get; set; }

    [Column(TypeName = "enum('pendente','pago','cancelado')")]
    public string statusBoleto { get; set; }

    [Column(TypeName = "timestamp")]
    public DateTime dataCriacao { get; set; }

    [StringLength(255)]
    public string observacaoBoleto { get; set; }

    [Column(TypeName = "int(11)")]
    public int usuarioInclusao { get; set; }

    [ForeignKey("donoBoleto")]
    [InverseProperty("boletosdonoBoletoNavigation")]
    public virtual usuario donoBoletoNavigation { get; set; }

    [ForeignKey("usuarioInclusao")]
    [InverseProperty("boletosusuarioInclusaoNavigation")]
    public virtual usuario usuarioInclusaoNavigation { get; set; }
}
