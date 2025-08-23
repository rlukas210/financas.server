using System;
using System.Collections.Generic;

namespace FinancasServer.Models;

public partial class TransacaoCartao
{
    public int IdTransacao { get; set; }

    public int IdCartao { get; set; }

    public string Descricao { get; set; }

    public decimal Valor { get; set; }

    public DateOnly Data { get; set; }

    public int ParcelaAtual { get; set; }

    public int ParcelaTotal { get; set; }

    public int Categoria { get; set; }

    public string Status { get; set; }

    public DateTime DataCriacao { get; set; }

    public string Observacao { get; set; }

    public int UsuarioInclusao { get; set; }

    public virtual Categoria CategoriaNavigation { get; set; }

    public virtual Cartao IdCartaoNavigation { get; set; }

    public virtual Usuario UsuarioInclusaoNavigation { get; set; }
}
