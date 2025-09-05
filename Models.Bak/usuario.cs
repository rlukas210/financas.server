using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancasServer.Models;

[Index("emailUsuario", Name = "emailUsuario", IsUnique = true)]
public partial class usuario
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int idUsuario { get; set; }

    [Required]
    [StringLength(100)]
    public string nomeUsuario { get; set; }

    [Required]
    [StringLength(100)]
    public string emailUsuario { get; set; }

    [Required]
    [StringLength(255)]
    public string senhaUsuario { get; set; }

    [Required]
    [StringLength(50)]
    public string cargoUsuario { get; set; }

    [Column(TypeName = "enum('ativo','inativo')")]
    public string statusUsuario { get; set; }

/*    [InverseProperty("donoBoletoNavigation")]
    public virtual ICollection<boletos> boletosdonoBoletoNavigation { get; set; } = new List<boletos>();

    [InverseProperty("usuarioInclusaoNavigation")]
    public virtual ICollection<boletos> boletosusuarioInclusaoNavigation { get; set; } = new List<boletos>();

    [InverseProperty("idUsuarioNavigation")]
    public virtual ICollection<cartoes> cartoes { get; set; } = new List<cartoes>();

    [InverseProperty("usuarioInclusaoNavigation")]
    public virtual ICollection<despesacartao> despesacartao { get; set; } = new List<despesacartao>();

    [InverseProperty("donoDespesaNavigation")]
    public virtual ICollection<divisaotransacao> divisaotransacao { get; set; } = new List<divisaotransacao>();

    [InverseProperty("idUsuarioNavigation")]
    public virtual ICollection<faturas> faturas { get; set; } = new List<faturas>();

    [InverseProperty("dono")]
    public virtual ICollection<transacoes> transacoes { get; set; } = new List<transacoes>();
    */
}
