using System.ComponentModel.DataAnnotations;

namespace Models;

public class Categoria
{
    [Key]
    public int IdCategoria { get; init; }
    [Required,  MaxLength(64)]
    public string NomeCategoria { get; set; }
}