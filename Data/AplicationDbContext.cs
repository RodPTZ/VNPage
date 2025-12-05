using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using VNpage.Models;

namespace VNpage.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NovelaVisual> NovelasVisuales { get; set; } = default!;
        public DbSet<Comentario> Comentarios { get; set; }
//        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<Resena> Resenas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Opcional: indices, longitudes, relaciones explícitas si quieres
            modelBuilder.Entity<NovelaVisual>()
                .HasMany(n => n.Resenas)
                .WithOne(r => r.NovelaVisual)
                .HasForeignKey(r => r.NovelaVisualId)
                .OnDelete(DeleteBehavior.SetNull);

           //modelBuilder.Entity<Usuario>()
            //.HasMany(u => u.Resenas)
            //.WithOne(r => r.Usuario)
            //.HasForeignKey(r => r.UsuarioId)
            //.OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Resena>().ToTable("Resenas");
            modelBuilder.Entity<NovelaVisual>().ToTable("Novelas");
        }
    }
    
}
