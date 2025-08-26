namespace financas.server.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }

    public virtual ICollection<Transacao> Transacoes { get; set; }
}

}