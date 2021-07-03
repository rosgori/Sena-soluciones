using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LabApp.Models
{
    public partial class lab_mundoContext : DbContext
    {
        public lab_mundoContext()
        {
        }

        public lab_mundoContext(DbContextOptions<lab_mundoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Visitante> Visitantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=lab_mundo;user=rosgori;password=micontraseña", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleado");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(20)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rol)
                    .HasMaxLength(20)
                    .HasColumnName("rol");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(25)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Rol)
                    .HasMaxLength(20)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<Visitante>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PRIMARY");

                entity.ToTable("visitante");

                entity.Property(e => e.Codigo)
                    .ValueGeneratedNever()
                    .HasColumnName("codigo");

                entity.Property(e => e.Correo)
                    .HasMaxLength(30)
                    .HasColumnName("correo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rol)
                    .HasMaxLength(30)
                    .HasColumnName("rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
