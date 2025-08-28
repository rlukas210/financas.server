using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
#pragma warning disable CS8632
{
    //TODO: DUPLICIDADE DE CHAVES ESTRANGEIRAS
#warning There are duplicate foreign keys
#warning Check the relationships and ensure they are correctly defined
    
   public class Fatura
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFatura { get; set; }

       // public Guid IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

       // public int IdCartao { get; set; }
        public virtual Cartao Cartao { get; set; }

        public int Mes { get; set; }
        public int Ano { get; set; }

        public decimal ValorTotal { get; set; }

        public StatusFatura Status { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public string? Observacao { get; set; }

        // public int UsuarioInclusao { get; set; }
        // public virtual Usuario UsuarioInclusaoNavigation { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }

public enum StatusFatura
{
    Pendente,
    Paga,
    Cancelada
}

}