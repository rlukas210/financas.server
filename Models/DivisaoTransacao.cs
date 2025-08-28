namespace financas.server.Models
{
   public class DivisaoTransacao
{
    public int Id { get; set; }

    public int TransacaoId { get; set; }
    public virtual Transacao Transacao { get; set; }

    public Guid UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }

    public decimal Valor { get; set; }
    #pragma warning disable CS8632
    public string? Observacao { get; set; }
}

}