using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
{
    public class Categoria
    {
        [Key, Column("id_categoria")]
        public int IdCategoria { get; set; }
        [Required, Column("nome_categoria"), MaxLength(100)]
        public string Nome { get; set; }
        [Column("descricao_categoria")]
        public string? Descricao { get; set; }

    public virtual ICollection<Transacao> Transacoes { get; set; }
}

}