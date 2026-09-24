using System.ComponentModel.DataAnnotations;

namespace Models;

public class Usuario
{
    [Key]
    public Guid IdUsuario { get; init; } =  Guid.CreateVersion7();
    
    [MinLength(3), MaxLength(100)]
    public String NomeUsuario { get; set; } 
    [Required, EmailAddress] // alternativa ao [Unique]
    public String EmailUsuario { get; set; }
    [Required, MinLength(8), MaxLength(128)] // como se livrar disso durante as operações?
    public String SenhaUsuario { get; set; }
    
}