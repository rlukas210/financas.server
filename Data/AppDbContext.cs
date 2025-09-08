using financas.server.Models;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        //  public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<StatusUsuario>();

            base.OnModelCreating(modelBuilder);
        }


    }
}