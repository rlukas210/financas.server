

namespace financas.server.Models
{
public class Usuario
{
    public int IdUsuario { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Cargo { get; set; }
    public StatusUsuario Status { get; set; }

    public virtual ICollection<Transacao> Transacoes { get; set; }
    public virtual ICollection<Fatura> Faturas { get; set; }
    public virtual ICollection<Pagamento> Pagamentos { get; set; }
}

public enum StatusUsuario
{
    Ativo,
    Inativo
}

}