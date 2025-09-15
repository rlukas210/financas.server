using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace financas.server.Models
{
    public class Fatura
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFatura { get; set; }
        [Required]
        public DateOnly MesReferencia { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }
        [Required]
        public Cartao Cartao { get; set; }
        public List<Despesas> Despesas { get; set; } = new List<Despesas>();
        
    }
}