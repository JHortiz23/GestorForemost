using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestorForemost.Models
{
    public partial class GestorForemostContext : DbContext
    {
        public GestorForemostContext()
        {
        }

        public GestorForemostContext(DbContextOptions<GestorForemostContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCliente> TbClientes { get; set; } = null!;
        public virtual DbSet<TbColaborador> TbColaboradors { get; set; } = null!;

        public virtual DbSet<TbFactura> TbFacturas { get; set; } = null!;
        public virtual DbSet<TbGestionSaldo> TbGestionSaldos { get; set; } = null!;
        public virtual DbSet<TbPuesto> TbPuestos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdentificacionCliente);

                entity.ToTable("tbCliente");

                entity.Property(e => e.IdentificacionCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("identificacionCliente");

                entity.Property(e => e.Apellido1Cliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido1Cliente");

                entity.Property(e => e.Apellido2Cliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido2Cliente");

                entity.Property(e => e.CorreoCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correoCliente");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccionCliente");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.TelefonoCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefonoCliente");
            });

            modelBuilder.Entity<TbColaborador>(entity =>
            {
                entity.HasKey(e => e.IdentificacionColaborador);

                entity.ToTable("tbColaborador");

                entity.Property(e => e.IdentificacionColaborador)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("identificacionColaborador");

                entity.Property(e => e.Apellido1Colaborador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido1Colaborador");

                entity.Property(e => e.Apellido2Colaborador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido2Colaborador");

                entity.Property(e => e.CorreoColaborador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correoColaborador");

                entity.Property(e => e.EstadoColaborador).HasColumnName("estadoColaborador");

                entity.Property(e => e.FechaIngresoColab)
                    .HasColumnType("date")
                    .HasColumnName("fechaIngresoColab");

                entity.Property(e => e.NombreColaborador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreColaborador");

                entity.Property(e => e.PaisColaborador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("paisColaborador");

                entity.Property(e => e.PuestoColaborador).HasColumnName("puestoColaborador");

                entity.Property(e => e.TelefonoColaborador)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefonoColaborador");

                entity.HasOne(d => d.PuestoColaboradorNavigation)
                    .WithMany(p => p.TbColaboradors)
                    .HasForeignKey(d => d.PuestoColaborador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbColaborador_tbPuesto");
            });

            modelBuilder.Entity<TbFactura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("tbFactura");

                entity.Property(e => e.IdFactura).HasColumnName("idFactura");

                entity.Property(e => e.ClienteFactura)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("clienteFactura");

                entity.Property(e => e.ColaboradorFactura)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("colaboradorFactura");

                entity.Property(e => e.EstadoFactura).HasColumnName("estadoFactura");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("date")
                    .HasColumnName("fechaFactura");

                entity.Property(e => e.MontoFactura)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("montoFactura");

                entity.Property(e => e.TipoFactura)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipoFactura");

                entity.HasOne(d => d.ClienteFacturaNavigation)
                    .WithMany(p => p.TbFacturas)
                    .HasForeignKey(d => d.ClienteFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFactura_tbCliente");

                entity.HasOne(d => d.ColaboradorFacturaNavigation)
                    .WithMany(p => p.TbFacturas)
                    .HasForeignKey(d => d.ColaboradorFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbFactura_tbColaborador");
            });

            modelBuilder.Entity<TbGestionSaldo>(entity =>
            {
                entity.HasKey(e => e.IdSaldo);

                entity.ToTable("tbGestionSaldo");

                entity.Property(e => e.IdSaldo).HasColumnName("idSaldo");

                entity.Property(e => e.EstadoSaldo).HasColumnName("estadoSaldo");

                entity.Property(e => e.FechaAsignSaldo)
                    .HasColumnType("date")
                    .HasColumnName("fechaAsignSaldo");

                entity.Property(e => e.IdFacturaSaldo).HasColumnName("idFacturaSaldo");

                entity.Property(e => e.IdGestorSaldo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idGestorSaldo");

                entity.HasOne(d => d.IdFacturaSaldoNavigation)
                    .WithMany(p => p.TbGestionSaldos)
                    .HasForeignKey(d => d.IdFacturaSaldo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbGestionSaldo_tbFactura");

                entity.HasOne(d => d.IdGestorSaldoNavigation)
                    .WithMany(p => p.TbGestionSaldos)
                    .HasForeignKey(d => d.IdGestorSaldo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbGestionSaldo_tbColaborador");
            });

            modelBuilder.Entity<TbPuesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto);

                entity.ToTable("tbPuesto");

                entity.Property(e => e.IdPuesto).HasColumnName("idPuesto");

                entity.Property(e => e.NombrePuesto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombrePuesto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
