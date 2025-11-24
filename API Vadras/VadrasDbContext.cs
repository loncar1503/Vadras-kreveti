using Domain;
using Microsoft.EntityFrameworkCore;
namespace API_Vadras
{
    public class VadrasDbContext : DbContext
    {
        public VadrasDbContext(DbContextOptions<VadrasDbContext> options): base(options)
        {
            
        }

        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<Porudzbina> Porudzbine { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<StavkaPorudzbine> StavkePorudzbine { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StavkaPorudzbine>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<StavkaPorudzbine>()
                .HasIndex(s => new { s.PorudzbinaId, s.Rb })
                .IsUnique();

            modelBuilder.Entity<StavkaPorudzbine>()
                .HasOne(s => s.Porudzbina)
                .WithMany(p => p.Stavke)
                .HasForeignKey(s => s.PorudzbinaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StavkaPorudzbine>()
                .HasOne(s => s.Proizvod)
                .WithMany() // ako proizvod nema listu stavki
                .HasForeignKey(s => s.ProizvodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
