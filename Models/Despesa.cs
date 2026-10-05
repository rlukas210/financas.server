namespace Models;

public class Despesa
{
    public Guid IdDespesa { get; } = Guid.CreateVersion7();
    /* TODO: Estabelecimento deve ser referenciado aqui!
    o sistema cadastra o lançamento conforme o original da fonte (ex: fatura)
    e a tabela de estabelecimento faz uma
    espécie de "lookup" para associar ao estabelecimento correto
    por meio de uma pesquisa do nome recebido durante o lançamento
    ex:
    ESTABEL.SEUZE09 == Id tal, Estabelecimento Seu Zé
    */
        
    public string Descricao { get; set; }
    
}