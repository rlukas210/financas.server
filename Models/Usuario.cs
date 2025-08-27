

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
{
public class Usuario
{
    [Key]
    public Guid IdUsuario { get; set; }
    [Required, MaxLength(100)]
    public string Nome { get; set; }
    [Required, MaxLength(100), EmailAddress]
    public string Email { get; set; }
    [Required, MinLength(8),MaxLength(100),PasswordPropertyText]
    public string Senha { get; set; }
    [NotMapped]
    public string Cargo { get; set; }
    public StatusUsuario Status { get; set; } = StatusUsuario.Ativo;

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