using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
    public class Cartao
    {
        [Key]
        public Guid IdCartao { get; set; }

        [Required, MaxLength(50)]
        public string NomeCartao { get; set; }

        [Required, MaxLength(50)]
        public string BandeiraCartao { get; set; }

        [Required, StringLength(4, MinimumLength = 4)]
        public string NumeroCartao { get; set; }

        public Usuarios DonoCartao { get; set; }

        //TODO: varios usuarios podem usar esse cartão, desde que com permissões adequadas
        // O dono pode designar despesas para o usuário, e o mesmo aceitar ou contestar.
        // public List<Usuarios> UsuariosAutorizados { get; set; }

        [Required]
        public DateOnly ValidadeCartao { get; set; }

        [Required, Precision(18, 2)]
        public decimal LimiteCartao { get; set; }

        public StatusCartao Status { get; set; } = StatusCartao.ativo;

        [MaxLength(128)]
        public string Observacoes { get; set; }

        public Cartao() { }

        public Cartao(string nomeCartao, string bandeiraCartao, string numeroCartao, Usuarios donoCartao, DateOnly validadeCartao, decimal limiteCartao, string observacoes)
        {
            IdCartao = Guid.NewGuid();
            NomeCartao = nomeCartao;
            BandeiraCartao = bandeiraCartao;
            NumeroCartao = numeroCartao;
            DonoCartao = donoCartao;
            ValidadeCartao = validadeCartao;
            LimiteCartao = limiteCartao;
            Observacoes = observacoes;
        }
    }
}

public enum StatusCartao
{
    ativo,
    bloqueado,
    cancelado
}