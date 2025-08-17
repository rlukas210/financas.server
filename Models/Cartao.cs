namespace financas.server.Models
{
    public class Cartao
    {
        public Guid IdCartao { get; set; }
        public string NomeCartao { get; set; }
        public string BandeiraCartao { get; set; }
        public Usuarios DonoCartao { get; set; }
        //TODO: varios usuarios podem usar esse cartão, desde que com permissões adequadas
        // O dono pode designar despesas para o usuário, e o mesmo aceitar ou contestar.
        // public List<Usuarios> UsuariosAutorizados { get; set; }
        public DateOnly DataValidade { get; set; }
        public decimal Limite { get; set; }
        //TODO: enum para status
        //public CartaoStatus Status { get; set; }
    }
}