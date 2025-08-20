using System.ComponentModel.DataAnnotations;

namespace financas.server.Models
{
    public class Usuarios
    {
        [Key]
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        // TODO: ENUM -> public string Cargo { get; set; }
        public bool UsuarioAtivo { get; set; } = true;

        public Usuarios(){}
        public Usuarios(string nome, string email, string username, string senha)
        {
            IdUsuario = Guid.NewGuid();
            Nome = nome;
            Username = username;
            Email = email;
            Senha = senha;
           // Cargo = cargo;
        }

    }
}