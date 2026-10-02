namespace Models.DbContext;

using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Estabelecimento>  Estabelecimentos { get; set; }
    public DbSet<CategoriaEstabelecimento> CatEstabelecimento { get; set; }
    public DbSet<Cartao> Cartoes { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder
        .UseSnakeCaseNamingConvention();
}