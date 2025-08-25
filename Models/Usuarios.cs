using System.ComponentModel.DataAnnotations.Schema;

namespace FinancasServer.Models;

[Table("Usuarios")]
public class Usuario
{
    public int IdUsuario { get; set; }

    public string Nome { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }

    public string Cargo { get; set; }

    public string Status { get; set; }

    public virtual ICollection<Cartao> Cartaos { get; set; } = new List<Cartao>();

    public virtual ICollection<Fatura> FaturaIdUsuarioNavigations { get; set; } = new List<Fatura>();

    public virtual ICollection<Fatura> FaturaUsuarioInclusaoNavigations { get; set; } = new List<Fatura>();

    public virtual ICollection<TransacaoBoleto> TransacaoBoletos { get; set; } = new List<TransacaoBoleto>();

    public virtual ICollection<TransacaoCartao> TransacaoCartoes { get; set; } = new List<TransacaoCartao>();

    public virtual ICollection<TransacaoDinheiro> TransacaoDinheiros { get; set; } = new List<TransacaoDinheiro>();

    public virtual ICollection<TransacaoPessoa> TransacaoPessoaIdUsuarioNavigations { get; set; } = new List<TransacaoPessoa>();

    public virtual ICollection<TransacaoPessoa> TransacaoPessoaUsuarioInclusaoNavigations { get; set; } = new List<TransacaoPessoa>();
}
