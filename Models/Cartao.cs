using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace financas.server.Models
{
    public class Cartao
    {
        [Key]
        public Guid IdCartao { get; set; }
        [Required, MaxLength(100)]
        public string NomeCartao { get; set; }
        [Required, StringLength(4, MinimumLength = 4)]
        public string NumeroCartao { get; set; }
        [Required, MaxLength(50)]
        public string BandeiraCartao { get; set; }
        [Required]
        public DateOnly ValidadeCartao { get; set; }

      //  public 
    }
}