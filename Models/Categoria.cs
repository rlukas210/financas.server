using System.ComponentModel.DataAnnotations;

namespace financas.server.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required, MaxLength(100)]
        public string Nome { get; set; }
        public string? Descricao { get; set; }

    public virtual ICollection<Transacao> Transacoes { get; set; }
}

}