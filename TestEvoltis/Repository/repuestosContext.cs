using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace Repository
{
    public partial class repuestosContext : DbContext
    {
        public repuestosContext()
        {
        }

        public repuestosContext(DbContextOptions<repuestosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Detallefactura> Detallefacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Repuesto> Repuestos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=Ese1234;database=repuestos", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Apellido).HasMaxLength(45);

                entity.Property(e => e.Nombre).HasMaxLength(45);

                entity.Property(e => e.Telefono).HasMaxLength(45);
            });

            modelBuilder.Entity<Detallefactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura)
                    .HasName("PRIMARY");

                entity.ToTable("detallefactura");

                entity.HasIndex(e => e.IdFactura, "Factura_idx");

                entity.HasIndex(e => e.IdRepuesto, "Repuesto_idx");

                entity.Property(e => e.IdDetalleFactura).HasColumnName("idDetalleFactura");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Detallefacturas)
                    .HasForeignKey(d => d.IdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Factura");

                entity.HasOne(d => d.IdRepuestoNavigation)
                    .WithMany(p => p.Detallefacturas)
                    .HasForeignKey(d => d.IdRepuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Repuesto");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PRIMARY");

                entity.ToTable("factura");

                entity.Property(e => e.IdFactura)
                    .ValueGeneratedNever()
                    .HasColumnName("idFactura");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PRIMARY");

                entity.ToTable("marcas");

                entity.Property(e => e.Nombre).HasMaxLength(45);
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.HasKey(e => e.IdRepuestos)
                    .HasName("PRIMARY");

                entity.ToTable("repuestos");

                entity.HasIndex(e => e.IdMarca, "IdMarca_idx");

                entity.Property(e => e.IdRepuestos).HasColumnName("idRepuestos");

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.NombreRepuesto)
                    .HasMaxLength(45)
                    .HasColumnName("Nombre Repuesto");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Repuestos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdMarca");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
