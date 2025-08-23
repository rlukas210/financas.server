using System;
using System.Collections.Generic;

namespace FinancasServer.Models;

public partial class Cartao
{
    public int idCartao { get; set; }

    public string nomeCartao { get; set; }

    public string bandeira { get; set; }

    public int idUsuario { get; set; }

    public string numero { get; set; }

    public DateOnly validade { get; set; }

    public decimal limite { get; set; }

    public string status { get; set; }

    public string descricaoStatus { get; set; }

    public virtual ICollection<Fatura> Faturas { get; set; } = new List<Fatura>();

    public virtual Usuario IdUsuarioNavigation { get; set; }

    public virtual ICollection<TransacaoCartao> TransacaoCartoes { get; set; } = new List<TransacaoCartao>();
}
