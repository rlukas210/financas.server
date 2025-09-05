using System;
using System.Collections.Generic;
using FinancasServer.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

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

    public virtual DbSet<boletos> boletos { get; set; }

    public virtual DbSet<cartoes> cartoes { get; set; }

    public virtual DbSet<categorias> categorias { get; set; }

    public virtual DbSet<despesacartao> despesacartao { get; set; }

    public virtual DbSet<divisaotransacao> divisaotransacao { get; set; }

    public virtual DbSet<faturas> faturas { get; set; }

    public virtual DbSet<transacoes> transacoes { get; set; }

    public virtual DbSet<usuario> usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=teste3d;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<boletos>(entity =>
        {
            entity.HasKey(e => e.idBoleto).HasName("PRIMARY");

            entity.Property(e => e.idBoleto).ValueGeneratedNever();
            entity.Property(e => e.dataCriacao).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.statusBoleto).HasDefaultValueSql("'pendente'");

          /*  entity.HasOne(d => d.donoBoletoNavigation).WithMany(p => p.boletosdonoBoletoNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boletos_ibfk_1");

            entity.HasOne(d => d.usuarioInclusaoNavigation).WithMany(p => p.boletosusuarioInclusaoNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("boletos_ibfk_2"); */
        });

        modelBuilder.Entity<cartoes>(entity =>
        {
            entity.HasKey(e => e.idCartao).HasName("PRIMARY");

            entity.Property(e => e.idCartao).ValueGeneratedNever();
            entity.Property(e => e.numeroCartao).HasDefaultValueSql("'0'");
            entity.Property(e => e.statusCartao).HasDefaultValueSql("'ativo'");

        /*    entity.HasOne(d => d.idUsuarioNavigation).WithMany(p => p.cartoes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cartoes_ibfk_1"); */
        });

        modelBuilder.Entity<categorias>(entity =>
        {
            entity.HasKey(e => e.idCategoria).HasName("PRIMARY");

            entity.Property(e => e.idCategoria).ValueGeneratedNever();
        });

        modelBuilder.Entity<despesacartao>(entity =>
        {
            entity.HasKey(e => e.idDespesa).HasName("PRIMARY");

            entity.Property(e => e.idDespesa).ValueGeneratedNever();
            entity.Property(e => e.data_criacao).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.parcelaAtual).HasDefaultValueSql("'1'");
            entity.Property(e => e.parcelaTotal).HasDefaultValueSql("'1'");
            entity.Property(e => e.status).HasDefaultValueSql("'pendente'");

            entity.HasOne(d => d.categoriaNavigation).WithMany(p => p.despesacartao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("despesacartao_ibfk_3");

            entity.HasOne(d => d.idCartaoNavigation).WithMany(p => p.despesacartao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("despesacartao_ibfk_2");

        /*    entity.HasOne(d => d.usuarioInclusaoNavigation).WithMany(p => p.despesacartao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("despesacartao_ibfk_1"); */
        });

        modelBuilder.Entity<divisaotransacao>(entity =>
        {
            entity.HasKey(e => e.idDivisao).HasName("PRIMARY");

            entity.Property(e => e.idDivisao).ValueGeneratedNever();
            entity.Property(e => e.data_criacao).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.status).HasDefaultValueSql("'pendente'");

          /*  entity.HasOne(d => d.donoDespesaNavigation).WithMany(p => p.divisaotransacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("divisaotransacao_ibfk_2"); */

            entity.HasOne(d => d.idDespesaNavigation).WithMany(p => p.divisaotransacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("divisaotransacao_ibfk_1");
        });

        modelBuilder.Entity<faturas>(entity =>
        {
            entity.HasKey(e => e.idFatura).HasName("PRIMARY");

            entity.Property(e => e.idFatura).ValueGeneratedNever();
            entity.Property(e => e.dataCriacao).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.statusFatura).HasDefaultValueSql("'pendente'");

            entity.HasOne(d => d.idCartaoNavigation).WithMany(p => p.faturas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("faturas_ibfk_2");

          /*  entity.HasOne(d => d.idUsuarioNavigation).WithMany(p => p.faturas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("faturas_ibfk_1"); */
        });

        modelBuilder.Entity<transacoes>(entity =>
        {
            entity.HasKey(e => e.idTransacao).HasName("PRIMARY");

            entity.Property(e => e.idTransacao).ValueGeneratedNever();
            entity.Property(e => e.dataLancamento).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.statusTransacao).HasDefaultValueSql("'pendente'");

          /*  entity.HasOne(d => d.dono).WithMany(p => p.transacoes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacoes_ibfk_1"); */

            entity.HasOne(d => d.fatura).WithMany(p => p.transacoes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transacoes_ibfk_2");
        });

        modelBuilder.Entity<usuario>(entity =>
        {
            entity.HasKey(e => e.idUsuario).HasName("PRIMARY");

            entity.Property(e => e.idUsuario).ValueGeneratedNever();
            entity.Property(e => e.statusUsuario).HasDefaultValueSql("'ativo'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
