namespace Models;

public class Email
{
    public Guid IdEmail { get; set; } = Guid.NewGuid();

    public string Rementente { get; set; } =  string.Empty;
    public string Destinatario { get; set; } =  string.Empty;
    public DateTime DataEmail { get; set; } = DateTime.UtcNow;
    public string Assunto { get; set; } = string.Empty;
    public string Corpo { get; set; } = string.Empty;

    public List<EmailLink> Links { get; set; } = new();
    //Algum tipo de VFS ou Object Storage tipo S3 cairia muito bem aqui
    public List<EmailAnexo> Anexos { get; set; } = new();
}