using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
    public class DivisaoTransacao
    {
        [Key]
        public int IdTransacao { get; set; }
        [Required]
        public virtual Transacao Transacao { get; set; }
        [Required]
        public virtual Usuario Usuario { get; set; }
        [Required, Precision(10, 2)]
        public decimal Valor { get; set; }
        [MaxLength(200)]
        public string? Observacao { get; set; }
        public int TransacaoId { get; set; }
        public Guid UsuarioId { get; set; }
    }

}