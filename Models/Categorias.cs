using System.ComponentModel.DataAnnotations;

namespace financas.server.Models
{
    public class Categorias
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required, MaxLength(100)]
        public string NomeCategoria { get; set; }
        public string? DescricaoCategoria { get; set; }   
    }
}