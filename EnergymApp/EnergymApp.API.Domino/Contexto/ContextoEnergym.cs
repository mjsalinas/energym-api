using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EnergymApp.API.Domino.ModelosDB;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EnergymApp.API.Domino.Contexto
{
    public partial class ContextoEnergym : DbContext
    {
        public ContextoEnergym()
        {
        }

        public ContextoEnergym(DbContextOptions<ContextoEnergym> options)
            : base(options)
        {
        }

        public virtual DbSet<CampoSeguimiento> CampoSeguimiento { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DatosSeguimiento> DatosSeguimiento { get; set; }
        public virtual DbSet<ModalidadGrupal> ModalidadGrupal { get; set; }
        public virtual DbSet<Oportunidades> Oportunidades { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<RegistroPagos> RegistroPagos { get; set; }
        public virtual DbSet<TipoDePlan> TipoDePlan { get; set; }
        public virtual DbSet<UnidadesMedida> UnidadesMedida { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("data source=157.230.13.243;user=sa;password=password;initial catalog=energym", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CampoSeguimiento>(entity =>
            {
                entity.HasKey(e => e.IdCampoSeguimiento)
                    .HasName("PRIMARY");

                entity.ToTable("campo_seguimiento");

                entity.Property(e => e.IdCampoSeguimiento)
                    .HasColumnName("id_campo_seguimiento")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampoSeguimiento1)
                    .IsRequired()
                    .HasColumnName("campo_seguimiento")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdUnidadMedida).HasColumnName("id_unidad_medida");

                entity.Property(e => e.RegistroOculto).HasColumnName("registro_oculto");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("clientes");

                entity.HasIndex(e => e.IdGrupo)
                    .HasName("id_grupo_idx");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.EstadoCliente)
                    .IsRequired()
                    .HasColumnName("estado_cliente")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("date");

                entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumeroTelefono)
                    .IsRequired()
                    .HasColumnName("numero_telefono")
                    .HasColumnType("varchar(8)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TipoPlan).HasColumnName("tipo_plan");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_grupo");
            });

            modelBuilder.Entity<DatosSeguimiento>(entity =>
            {
                entity.HasKey(e => new { e.IdCamposSeguimiento, e.IdCliente, e.FechaRegistro })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("datos_seguimiento");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente_idx");

                entity.Property(e => e.IdCamposSeguimiento).HasColumnName("id_campos_seguimiento");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatoSeguimiento)
                    .IsRequired()
                    .HasColumnName("dato_seguimiento")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<ModalidadGrupal>(entity =>
            {
                entity.HasKey(e => e.IdGrupo)
                    .HasName("PRIMARY");

                entity.ToTable("modalidad_grupal");

                entity.HasIndex(e => e.IdPlan)
                    .HasName("id_plan_idx");

                entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");

                entity.Property(e => e.GrupoActivo).HasColumnName("grupo_activo");

                entity.Property(e => e.IdPlan).HasColumnName("id_plan");

                entity.Property(e => e.LiderGrupo).HasColumnName("lider_grupo");

                entity.Property(e => e.ModalidadGrupalcol)
                    .IsRequired()
                    .HasColumnName("modalidad_grupalcol")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdPlanNavigation)
                    .WithMany(p => p.ModalidadGrupal)
                    .HasForeignKey(d => d.IdPlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_plan");
            });

            modelBuilder.Entity<Oportunidades>(entity =>
            {
                entity.HasKey(e => e.IdOportunidad)
                    .HasName("PRIMARY");

                entity.ToTable("oportunidades");

                entity.HasIndex(e => e.IdOportunidad)
                    .HasName("id_oportunidad_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdOportunidad).HasColumnName("id_oportunidad");

                entity.Property(e => e.FechaTransaccion)
                    .HasColumnName("fecha_transaccion")
                    .HasColumnType("date");

                entity.Property(e => e.Oportunidad)
                    .IsRequired()
                    .HasColumnName("oportunidad")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TipoOportunidad)
                    .IsRequired()
                    .HasColumnName("tipo_oportunidad")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => e.IdPagos)
                    .HasName("PRIMARY");

                entity.ToTable("pagos");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente_idx");

                entity.HasIndex(e => e.IdPagos)
                    .HasName("id_pagos_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPagos).HasColumnName("id_pagos");

                entity.Property(e => e.EstadoDePago)
                    .IsRequired()
                    .HasColumnName("estado_de_pago")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FechaMaximaPago)
                    .HasColumnName("fecha_maxima_pago")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_cliente");
            });

            modelBuilder.Entity<RegistroPagos>(entity =>
            {
                entity.HasKey(e => e.IdRegistroPagos)
                    .HasName("PRIMARY");

                entity.ToTable("registro_pagos");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente_idx");

                entity.HasIndex(e => e.IdPagos)
                    .HasName("id_pagos");

                entity.HasIndex(e => e.IdRegistroPagos)
                    .HasName("id_registro_pagos_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdRegistroPagos).HasColumnName("id_registro_pagos");

                entity.Property(e => e.EstadoDePago)
                    .IsRequired()
                    .HasColumnName("estado_de_pago")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FechaRealizacionPago)
                    .HasColumnName("fecha_realizacion_pago")
                    .HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdPagos).HasColumnName("id_pagos");

                entity.HasOne(d => d.IdPagosNavigation)
                    .WithMany(p => p.RegistroPagos)
                    .HasForeignKey(d => d.IdPagos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_pagos");
            });

            modelBuilder.Entity<TipoDePlan>(entity =>
            {
                entity.HasKey(e => e.IdPlan)
                    .HasName("PRIMARY");

                entity.ToTable("tipo_de_plan");

                entity.Property(e => e.IdPlan).HasColumnName("id_plan");

                entity.Property(e => e.CostoPlan)
                    .HasColumnName("costo_plan")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.NoIntegrantes).HasColumnName("no_integrantes");

                entity.Property(e => e.NombrePlan)
                    .IsRequired()
                    .HasColumnName("nombre_plan")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.RegistroOculto).HasColumnName("registro_oculto");
            });

            modelBuilder.Entity<UnidadesMedida>(entity =>
            {
                entity.HasKey(e => e.IdUnidadMedida)
                    .HasName("PRIMARY");

                entity.ToTable("unidades_medida");

                entity.HasIndex(e => e.IdUnidadMedida)
                    .HasName("id_unidad_medida_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUnidadMedida).HasColumnName("id_unidad_medida");

                entity.Property(e => e.RegistroOculto)
                    .HasColumnName("registro_oculto")
                    .HasColumnType("tinyint(1) unsigned zerofill");

                entity.Property(e => e.UnidadMedida)
                    .IsRequired()
                    .HasColumnName("unidad_medida")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
