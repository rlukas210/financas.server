using System.ComponentModel.DataAnnotations;

namespace Models;

public class CategoriaEstabelecimento
{
    [Key]
    public int IdCategoriaEstabelecimento { get; init; }
    
    [Required,  MaxLength(64)]
    public string NomeCategoriaEstabelecimento { get; set; }
}