using etec_delivery_backend.Models;
using Microsoft.EntityFrameworkCore;
namespace etec_delivery_back.Data
{
    public class DbConfig : DbContext
    {
        public DbConfig(DbContextOptions<DbConfig> options) : base(options) 
        {
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<RotaEntrega> Entrega { get; set; }
            public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(
                entity =>
                {
                    entity.HasIndex(e => e.Email_Usuario).IsUnique();
                }
                );
        }
    }
    }
}
