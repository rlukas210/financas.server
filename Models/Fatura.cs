using System;
using System.Collections.Generic;

namespace FinancasServer.Models;

public partial class Fatura
{
    public int IdFatura { get; set; }

    public int IdUsuario { get; set; }

    public int IdCartao { get; set; }

    public int Mes { get; set; }

    public int Ano { get; set; }

    public decimal ValorTotal { get; set; }

    public string Status { get; set; }

    public DateTime DataCriacao { get; set; }

    public string Observacao { get; set; }

    public int UsuarioInclusao { get; set; }

    public virtual Cartao IdCartaoNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual Usuario UsuarioInclusaoNavigation { get; set; }
}
