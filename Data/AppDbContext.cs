using Microsoft.EntityFrameworkCore;
using FinancasServer.Models;

namespace FinancasServer.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cartao> Cartaos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Fatura> Faturas { get; set; }

    public virtual DbSet<Pagamento> Pagamentos { get; set; }

    public virtual DbSet<TransacaoBoleto> TransacaoBoletos { get; set; }

    public virtual DbSet<TransacaoCartao> TransacaoCartoes { get; set; }

    public virtual DbSet<TransacaoDinheiro> TransacaoDinheiros { get; set; }

    public virtual DbSet<TransacaoPessoa> TransacaoPessoas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
 */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cartao>(entity =>
        {
            entity.HasKey(e => e.idCartao).HasName("PRIMARY");

            entity.ToTable("cartao");

            entity.HasIndex(e => e.idUsuario, "idUsuario");

            entity.Property(e => e.idCartao).HasColumnType("int(11)");
            entity.Property(e => e.bandeira)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.descricaoStatus).HasMaxLength(255);
            entity.Property(e => e.idUsuario).HasColumnType("int(11)");
            entity.Property(e => e.limite).HasPrecision(10, 2);
            entity.Property(e => e.nomeCartao)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.numero)
                .IsRequired()
                .HasMaxLength(4);
            entity.Property(e => e.status)
                .HasDefaultValueSql("'ativo'")
                .HasColumnType("enum('ativo','bloqueado','cancelado','perdido')");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Cartaos)
                .HasForeignKey(d => d.idUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cartao_ibfk_1");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.Property(e => e.IdCategoria).HasColumnType("int(11)");
            entity.Property(e => e.Descricao).HasMaxLength(255);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Fatura>(entity =>
        {
            entity.HasKey(e => e.IdFatura).HasName("PRIMARY");

            entity.HasIndex(e => e.IdCartao, "idCartao");

            entity.HasIndex(e => e.IdUsuario, "idUsuario");

            entity.HasIndex(e => e.UsuarioInclusao, "usuarioInclusao");

            entity.Property(e => e.IdFatura).HasColumnType("int(11)");
            entity.Property(e => e.Ano).HasColumnType("int(11)");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.IdCartao).HasColumnType("int(11)");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.Mes).HasColumnType("int(11)");
            entity.Property(e => e.Observacao).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pendente'")
                .HasColumnType("enum('pendente','paga','cancelada')");
            entity.Property(e => e.UsuarioInclusao).HasColumnType("int(11)");
            entity.Property(e => e.ValorTotal).HasPrecision(10, 2);

            entity.HasOne(d => d.IdCartaoNavigation).WithMany(p => p.Faturas)
                .HasForeignKey(d => d.IdCartao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("faturas_ibfk_2");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.FaturaIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("faturas_ibfk_3");

            entity.HasOne(d => d.UsuarioInclusaoNavigation).WithMany(p => p.FaturaUsuarioInclusaoNavigations)
                .HasForeignKey(d => d.UsuarioInclusao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("faturas_ibfk_1");
        });

        modelBuilder.Entity<Pagamento>(entity =>
        {
            entity.HasKey(e => e.IdPagamento).HasName("PRIMARY");

            entity.HasIndex(e => e.IdFatura, "idFatura");

            entity.Property(e => e.IdPagamento).HasColumnType("int(11)");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.IdFatura).HasColumnType("int(11)");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pendente'")
                .HasColumnType("enum('pendente','pago','pago parcialmennte','cancelado')");
            entity.Property(e => e.Valor).HasPrecision(10, 2);

            entity.HasOne(d => d.IdFaturaNavigation).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.IdFatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagamentos_ibfk_1");
        });

        modelBuilder.Entity<TransacaoBoleto>(entity =>
        {
            entity.HasKey(e => e.IdTransacao).HasName("PRIMARY");

            entity.ToTable("transacaoboleto");

            entity.HasIndex(e => e.Categoria, "categoria");

            entity.HasIndex(e => e.UsuarioInclusao, "usuarioInclusao");

            entity.Property(e => e.IdTransacao).HasColumnType("int(11)");
            entity.Property(e => e.Categoria).HasColumnType("int(11)");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Observacao).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pendente'")
                .HasColumnType("enum('pendente','paga','cancelada')");
            entity.Property(e => e.UsuarioInclusao).HasColumnType("int(11)");
            entity.Property(e => e.Valor).HasPrecision(10, 2);

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.TransacaoBoletos)
                .HasForeignKey(d => d.Categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacaoboleto_ibfk_2");

            entity.HasOne(d => d.UsuarioInclusaoNavigation).WithMany(p => p.TransacaoBoletos)
                .HasForeignKey(d => d.UsuarioInclusao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacaoboleto_ibfk_1");
        });

        modelBuilder.Entity<TransacaoCartao>(entity =>
        {
            entity.HasKey(e => e.IdTransacao).HasName("PRIMARY");

            entity.ToTable("transacaocartao");

            entity.HasIndex(e => e.Categoria, "categoria");

            entity.HasIndex(e => e.IdCartao, "idCartao");

            entity.HasIndex(e => e.UsuarioInclusao, "usuarioInclusao");

            entity.Property(e => e.IdTransacao).HasColumnType("int(11)");
            entity.Property(e => e.Categoria).HasColumnType("int(11)");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.IdCartao).HasColumnType("int(11)");
            entity.Property(e => e.Observacao).HasMaxLength(255);
            entity.Property(e => e.ParcelaAtual)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");
            entity.Property(e => e.ParcelaTotal)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pendente'")
                .HasColumnType("enum('pendente','paga','cancelada')");
            entity.Property(e => e.UsuarioInclusao).HasColumnType("int(11)");
            entity.Property(e => e.Valor).HasPrecision(10, 2);

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.TransacaoCartoes)
                .HasForeignKey(d => d.Categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacaocartao_ibfk_3");

            entity.HasOne(d => d.IdCartaoNavigation).WithMany(p => p.TransacaoCartoes)
                .HasForeignKey(d => d.IdCartao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacaocartao_ibfk_2");

            entity.HasOne(d => d.UsuarioInclusaoNavigation).WithMany(p => p.TransacaoCartoes)
                .HasForeignKey(d => d.UsuarioInclusao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacaocartao_ibfk_1");
        });

        modelBuilder.Entity<TransacaoDinheiro>(entity =>
        {
            entity.HasKey(e => e.IdTransacao).HasName("PRIMARY");

            entity.ToTable("transacaodinheiro");

            entity.HasIndex(e => e.Categoria, "categoria");

            entity.HasIndex(e => e.UsuarioInclusao, "usuarioInclusao");

            entity.Property(e => e.IdTransacao).HasColumnType("int(11)");
            entity.Property(e => e.Categoria).HasColumnType("int(11)");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Observacao).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pendente'")
                .HasColumnType("enum('pendente','paga','cancelada')");
            entity.Property(e => e.UsuarioInclusao).HasColumnType("int(11)");
            entity.Property(e => e.Valor).HasPrecision(10, 2);

            entity.HasOne(d => d.CategoriaNavigation).WithMany(p => p.TransacaoDinheiros)
                .HasForeignKey(d => d.Categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacaodinheiro_ibfk_2");

            entity.HasOne(d => d.UsuarioInclusaoNavigation).WithMany(p => p.TransacaoDinheiros)
                .HasForeignKey(d => d.UsuarioInclusao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacaodinheiro_ibfk_1");
        });

        modelBuilder.Entity<TransacaoPessoa>(entity =>
        {
            entity.HasKey(e => e.IdTransacao).HasName("PRIMARY");

            entity.HasIndex(e => e.IdUsuario, "idUsuario");

            entity.HasIndex(e => e.UsuarioInclusao, "usuarioInclusao");

            entity.Property(e => e.IdTransacao).HasColumnType("int(11)");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.IdUsuario).HasColumnType("int(11)");
            entity.Property(e => e.Natureza)
                .IsRequired()
                .HasColumnType("enum('credito','debito','boleto','dinheiro')");
            entity.Property(e => e.Observacao).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pendente'")
                .HasColumnType("enum('pendente','paga','cancelada')");
            entity.Property(e => e.UsuarioInclusao).HasColumnType("int(11)");
            entity.Property(e => e.Valor).HasPrecision(10, 2);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TransacaoPessoaIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacaopessoas_ibfk_2");

            entity.HasOne(d => d.UsuarioInclusaoNavigation).WithMany(p => p.TransacaoPessoaUsuarioInclusaoNavigations)
                .HasForeignKey(d => d.UsuarioInclusao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacaopessoas_ibfk_1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Cargo)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Senha)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'ativo'")
                .HasColumnType("enum('ativo','inativo')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}git 
