using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ExamenAlfaContext : DbContext
{
    public ExamenAlfaContext()
    {
    }

    public ExamenAlfaContext(DbContextOptions<ExamenAlfaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Beca> Becas { get; set; }

    public virtual DbSet<BecasAlumno> BecasAlumnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ALIEN28; Database= ExamenAlfa; Trusted_Connection=True;TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumnos__460B4740874D81B7");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Beca>(entity =>
        {
            entity.HasKey(e => e.IdBecas).HasName("PK__Becas__3752862B4B47D477");

            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BecasAlumno>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IdAsignarBecas).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany()
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("FK__BecasAlum__IdAlu__145C0A3F");

            entity.HasOne(d => d.IdBecaNavigation).WithMany()
                .HasForeignKey(d => d.IdBeca)
                .HasConstraintName("FK__BecasAlum__IdBec__15502E78");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
