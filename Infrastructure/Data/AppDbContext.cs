using api_safe_trade.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_safe_trade.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Suspeito> Suspeitos { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<AvistamentoSuspeito> Avistamentos { get; set; }
        public DbSet<AbordagemSuspeito> Abordagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
