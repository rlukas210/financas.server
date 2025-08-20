using System.ComponentModel.DataAnnotations;

namespace financas.server.Models
{
    public class Categorias
    {
        [Key]
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public string Descricao { get; set; }

        public Categorias(){}
        public Categorias(string nomeCategoria, string descricao)
        {
            NomeCategoria = nomeCategoria;
            Descricao = descricao;
        }
    }
}