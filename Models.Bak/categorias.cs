using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinancasServer.Models;

public partial class categorias
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int idCategoria { get; set; }

    [Required]
    [StringLength(100)]
    public string nomeCategoria { get; set; }

    [StringLength(255)]
    public string descricaoCategoria { get; set; }

    [InverseProperty("categoriaNavigation")]
    public virtual ICollection<despesacartao> despesacartao { get; set; } = new List<despesacartao>();
}
