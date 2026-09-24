using System.ComponentModel.DataAnnotations;

namespace Models;

public class Estabelecimento
{
    [Key]
    public Guid IdEstabelecimento { get; init; } = Guid.CreateVersion7();
    [Required] public string NomeEstabelecimento { get; set; }

    public string? EmailEstabelecimento { get; set; }
    public string? TelefoneEstabelecimento { get; set; }

    public string[] NomeSecEstabelecimento { get; set; }

}
