using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaSatrack.Datos.Models;

public partial class SatrackContext : DbContext
{
    public SatrackContext()
    {
    }

    public SatrackContext(DbContextOptions<SatrackContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__02AA0785591606AF");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Categoria");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__ESTADO__9CF49395C4B5544F");

            entity.ToTable("ESTADO");

            entity.Property(e => e.IdEstado).HasColumnName("ID_Estado");
            entity.Property(e => e.NombreEstado)
                .HasMaxLength(50)
                .HasColumnName("Nombre_Estado");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__TAREA__0294B9E2101DFA54");

            entity.ToTable("TAREA");

            entity.Property(e => e.IdTarea).HasColumnName("ID_Tarea");
            entity.Property(e => e.CategoriaTarea).HasColumnName("Categoria_Tarea");
            entity.Property(e => e.DescripcionTarea)
                .HasColumnType("text")
                .HasColumnName("Descripcion_Tarea");
            entity.Property(e => e.EstadoTarea).HasColumnName("Estado_Tarea");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaFinalizacion)
                .HasColumnType("date")
                .HasColumnName("Fecha_Finalizacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("date")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.TituloTarea)
                .HasMaxLength(100)
                .HasColumnName("Titulo_Tarea");

            entity.HasOne(d => d.CategoriaTareaNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.CategoriaTarea)
                .HasConstraintName("FK__TAREA__Categoria__5165187F");

            entity.HasOne(d => d.EstadoTareaNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.EstadoTarea)
                .HasConstraintName("FK__TAREA__Estado_Ta__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
