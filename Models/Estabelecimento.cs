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

    //área das categorias:
    //categoria da despesa e do estabelecimento
    
    /* TODO: Essa entrada no banco de dados está gerando uma coluna
     chamada: 'categoria_estabelecimento_id_categoria_estabelecimento'
     do tipo 'integer' (ok)
     corrigir o nome para ficar menor, menos "feio" */ 
    public CategoriaEstabelecimento CategoriaEstabelecimento { get; set; }
    
    //essa é apenas uma sugestão, pode ser alterada durante a inserção de despesas
    /* TODO: Mesma situação da coluna acima, onde essa está sendo chamada como
     'categoria_sugerida_id_categoria'
     corrigir para padronizar */
    public Categoria CategoriaSugerida { get; set; }
}
