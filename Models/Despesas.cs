using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Models
{
    public class Despesas
    {
        [Key]
        public int IdDespesa { get; set; }
        [Required, MaxLength(100)]
        public string NomeFantasia { get; set; }
        [MaxLength(128)]
        public string Descricao { get; set; }
        [Required, Precision(18, 2)]
        public decimal ValorDespesa { get; set; }
        public DateOnly DataDespesa { get; set; }
        public Categorias Categoria { get; set; }

    }
}