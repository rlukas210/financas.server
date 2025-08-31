using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
{
public class Usuario
{
    [Key, Column("id_usuario")]
    public Guid IdUsuario { get; set; }
    [Required, Column("nome_usuario"), MaxLength(100)]
    public string Nome { get; set; }
    [Required, Column("email_usuario"), MaxLength(100), EmailAddress]
    public string Email { get; set; }
    [Required, Column("senha_usuario"), MinLength(8), MaxLength(128), PasswordPropertyText]
    public string Senha { get; set; }
        // [NotMapped]
        // public string Cargo { get; set; }
   
    public StatusUsuario StatusUsuario { get; set; } = StatusUsuario.Ativo;

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