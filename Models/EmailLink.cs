namespace Models;

public class EmailLink
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public Guid EmailId { get; set; }
    public string Url { get; set; } = string.Empty;
}