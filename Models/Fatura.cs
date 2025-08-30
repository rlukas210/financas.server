using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
   public class Fatura
    {
        [Key]
        public int IdFatura { get; set; }
        [Required]
        public virtual Usuario Dono { get; set; }
        [Required]
        public virtual Cartao Cartao { get; set; }
        [Required]
       public DateOnly MesReferencia { get; set; } // Mês/Ano da fatura
        [Required, Precision(10,2)]
        public decimal ValorTotal { get; set; }
        public StatusFatura Status { get; set; } = StatusFatura.Pendente;
        
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        [MaxLength(200)]
        public string? Observacao { get; set; }

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