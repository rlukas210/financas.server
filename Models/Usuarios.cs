using System.ComponentModel.DataAnnotations;

namespace financas.server.Models
{
    public class Usuarios
    {
        [Key]
        public Guid IdUsuario { get; set; }
        [Required, MaxLength(100)]
        public string NomeUsuario { get; set; }
        [Required, MaxLength(128), EmailAddress]
        public string EmailUsuario { get; set; }
        [Required, MaxLength(128), MinLength(8)]
        public string SenhaUsuario { get; set; }
        public StatusUsuario Status { get; set; } = StatusUsuario.Ativo;
    }
    
    public enum StatusUsuario
    {
        Ativo,
        Inativo
    }
}