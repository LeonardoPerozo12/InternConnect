using Microsoft.EntityFrameworkCore;
using InternConnect.Models;

namespace InternConnect.Context
{
    public class InternConnectContext : DbContext
    {
        public InternConnectContext(DbContextOptions<InternConnectContext> options) : base(options)
        {
        }

        public DbSet<Aplicacion> Aplicaciones { get; set; }
        public DbSet<Beneficios> Beneficios { get; set; }
        public DbSet<BeneficiosPasantia> BeneficiosPasantias { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Pasantia> Pasantias { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Rol> Roles { get; set; } // Agrega DbSet para Rol

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BeneficiosPasantia>(entity =>
            {
                entity.HasKey(e => new { e.IDBeneficios, e.IDPasantia });
            });

            modelBuilder.Entity<Aplicacion>(entity =>
            {
                entity.HasKey(e => e.IDAplicacion); // Establece la clave primaria

                // Define la clave compuesta IDEstudiante e IDPasantia
                entity.HasAlternateKey(e => new { e.IDEstudiante, e.IDPasantia });
            });

            // Configurar la relación entre Estudiante y Rol
            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Rol)
                .WithMany()
                .HasForeignKey(e => e.IDRol);

            // Configurar la relación entre Empresa y Rol
            modelBuilder.Entity<Empresa>()
                .HasOne(e => e.Rol)
                .WithMany()
                .HasForeignKey(e => e.IDRol);

            // Insertar roles predeterminados en la base de datos
            modelBuilder.Entity<Rol>().HasData(
                new Rol { IDRol = 1, Nombre = "Estudiante" },
                new Rol { IDRol = 2, Nombre = "Empresa" }
            );
        }
    }
}
