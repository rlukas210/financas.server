namespace FinancasServer.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    public virtual ICollection<TransacaoBoleto> TransacaoBoletos { get; set; } = new List<TransacaoBoleto>();

    public virtual ICollection<TransacaoCartao> TransacaoCartoes { get; set; } = new List<TransacaoCartao>();

    public virtual ICollection<TransacaoDinheiro> TransacaoDinheiros { get; set; } = new List<TransacaoDinheiro>();
}
