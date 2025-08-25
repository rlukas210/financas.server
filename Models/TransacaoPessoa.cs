namespace FinancasServer.Models;

public partial class TransacaoPessoa
{
    public int IdTransacao { get; set; }

    public int IdUsuario { get; set; }

    public decimal Valor { get; set; }

    public string Natureza { get; set; }

    public string Status { get; set; }

    public DateTime DataCriacao { get; set; }

    public string Observacao { get; set; }

    public int UsuarioInclusao { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }

    public virtual Usuario UsuarioInclusaoNavigation { get; set; }
}
