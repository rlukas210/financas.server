using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
    public class DivisaoTransacao
    {
        [Key, Column("id_divisao_transacao")]
        public int IdTransacao { get; set; }
        [Required, Column("transacao")]
        public virtual Transacao Transacao { get; set; }
        [Required, Column("id_usuario")]
        public virtual Usuario Usuario { get; set; }
        [Required, Column("valor"), Precision(10, 2)]
        public decimal Valor { get; set; }
        [Column("observacao"), MaxLength(200)]
        public string? Observacao { get; set; }
        [Column("transacao_id")]
        public int TransacaoId { get; set; }
      //  public Guid UsuarioId { get; set; }
    }

}