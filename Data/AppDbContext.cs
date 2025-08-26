using financas.server.Models;
using Microsoft.EntityFrameworkCore;
namespace FinancasServer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Tabelas
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Cartao> Cartoes { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Fatura> Faturas { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<DivisaoTransacao> DivisoesTransacao { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Enums salvos como string no banco
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Cartao>()
            .Property(c => c.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Transacao>()
            .Property(t => t.TipoTransacao)
            .HasConversion<string>();

        modelBuilder.Entity<Transacao>()
            .Property(t => t.FormaPagamento)
            .HasConversion<string>();

        modelBuilder.Entity<Transacao>()
            .Property(t => t.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Fatura>()
            .Property(f => f.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Pagamento>()
            .Property(p => p.Status)
            .HasConversion<string>();

        modelBuilder.Entity<Pagamento>()
            .Property(p => p.FormaPagamento)
            .HasConversion<string>();

        // Chave composta opcional para evitar conflitos futuros
        modelBuilder.Entity<DivisaoTransacao>()
            .HasIndex(d => new { d.TransacaoId, d.UsuarioId })
            .IsUnique(false); // Permite mais de uma divisão por transação por usuário

        // Relacionamento entre Fatura e Transacoes
        modelBuilder.Entity<Fatura>()
            .HasMany(f => f.Transacoes)
            .WithOne(t => t.Fatura)
            .HasForeignKey(t => t.FaturaId)
            .OnDelete(DeleteBehavior.SetNull);

        // Pagamento pode estar ligado a Fatura OU a Transacao
        modelBuilder.Entity<Pagamento>()
            .HasOne(p => p.Fatura)
            .WithMany(f => f.Pagamentos)
            .HasForeignKey(p => p.FaturaId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Pagamento>()
            .HasOne(p => p.Transacao)
            .WithMany()
            .HasForeignKey(p => p.TransacaoId)
            .OnDelete(DeleteBehavior.SetNull);

        // Relacionamento DivisaoTransacao
        modelBuilder.Entity<DivisaoTransacao>()
            .HasOne(d => d.Transacao)
            .WithMany(t => t.Divisoes)
            .HasForeignKey(d => d.TransacaoId);

        modelBuilder.Entity<DivisaoTransacao>()
            .HasOne(d => d.Usuario)
            .WithMany()
            .HasForeignKey(d => d.UsuarioId);
    }
}
