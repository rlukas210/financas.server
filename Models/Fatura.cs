using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
   public class Fatura
    {
        [Key, Column("id_fatura")]
        public int IdFatura { get; set; }
        [Required, Column("id_usuario")]
        public virtual Usuario Dono { get; set; }
        [Required, Column("id_cartao")]
        public virtual Cartao Cartao { get; set; }
        [Required, Column("mes_referencia")]
       public DateOnly MesReferencia { get; set; } // Mês/Ano da fatura
        [Required, Column("valor_total"), Precision(10,2)]
        public decimal ValorTotal { get; set; }
        public StatusFatura Status { get; set; } = StatusFatura.Pendente;
        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        [Column("observacao"), MaxLength(200)]
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