using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
#pragma warning disable CS8632
{
    public class Categoria
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }

    public virtual ICollection<Transacao> Transacoes { get; set; }
}

}