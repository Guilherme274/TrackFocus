using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Infraestructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Tipo_Exercicio>().HasData(
                new Tipo_Exercicio { Id = 1, Nome = "Musculação"},
                new Tipo_Exercicio { Id = 2, Nome = "Cardio"}                
            );
        }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Tipo_Exercicio> Tipos_Exercicios { get; set; }
        public DbSet<Serie_Musculacao> Series_Musculacao { get; set; }
        public DbSet<Cardio> Exercicios_Cardio { get; set; }
    }
}