namespace financas.server.Models
{
    public class DespesaCartao
    {
        public int IdDespesa { get; set; }
        public string NomeDespesa { get; set; }
        public string FantasiaDespesa { get; set; }
        public Categorias CategoriaDespesa { get; set; }
        public decimal ValorDespesa { get; set; }
        public DateTime Data { get; set; }
        public string? Descricao { get; set; }
        public Cartao Cartao { get; set; }
        public int ParcelaAtual { get; set; } = 1;
        public int ParcelaTotal { get; set; } = 1;

        public DespesaCartao(string nomeDespesa, string fantasiaDespesa, Categorias categoriaDespesa, decimal valorDespesa, DateTime data, string? descricao, Cartao cartao, int parcelaAtual, int parcelaTotal)
        {
            NomeDespesa = nomeDespesa;
            FantasiaDespesa = fantasiaDespesa;
            CategoriaDespesa = categoriaDespesa;
            ValorDespesa = valorDespesa;
            Data = data;
            Descricao = descricao;
            Cartao = cartao;
            ParcelaAtual = parcelaAtual;
            ParcelaTotal = parcelaTotal;
        }
    }
}