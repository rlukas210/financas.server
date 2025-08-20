using System.ComponentModel.DataAnnotations;

namespace financas.server.Models
{
    public class FaturaCartao
    {
        [Key]
        public int IdFatura { get; set; }
        public decimal ValorFatura { get; set; }
        public DateTime DataVencimento { get; set; }
        public Cartao Cartao { get; set; }
        public List<DespesaCartao> Despesas { get; set; } = new List<DespesaCartao>();
        public Usuarios UsuarioInclusao { get; set; }

        public FaturaCartao(decimal valorFatura, DateTime dataVencimento, Cartao cartao, Usuarios usuarioInclusao)
        {
            ValorFatura = valorFatura;
            DataVencimento = dataVencimento;
            Cartao = cartao;
            UsuarioInclusao = usuarioInclusao;
        }
    }
}