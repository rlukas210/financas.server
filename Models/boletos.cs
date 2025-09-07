using System.ComponentModel.DataAnnotations.Schema;

namespace financas.server.Models
{
    [NotMapped]
    public class Boletos
    {
        public int IdBoleto { get; set; }
        public Usuarios donoBoleto { get; set; }
        
    }
}