namespace financas.server.Models
{
   public class DivisaoTransacao
{
    public int Id { get; set; }

    public int TransacaoId { get; set; }
    public virtual Transacao Transacao { get; set; }

    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }

    public decimal Valor { get; set; }

    public string? Observacao { get; set; }
}

}