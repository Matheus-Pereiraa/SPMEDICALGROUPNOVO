using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SPMEDICALGROUP_SENAI_WEBAPI.Domains;

#nullable disable

namespace SPMEDICALGROUP_SENAI_WEBAPI.Context
{
    public partial class SPmedContext : DbContext
    {
        public SPmedContext()
        {
        }

        public SPmedContext(DbContextOptions<SPmedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioPaciente> UsuarioPacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-E2A5F39\\ASHUALA; Initial Catalog=SENAI_SPMEDICALDROUP; user id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__52A909518678D608");

                entity.ToTable("Clinica");

                entity.HasIndex(e => e.Cnpj, "UQ__Clinica__A299CC92514B2296")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__9B2AD1D8636D3A49");

                entity.Property(e => e.DataeHora).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdSituacao).HasDefaultValueSql("((3))");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__IdMedi__4E88ABD4");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__IdPaci__4F7CD00D");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Consulta__IdSitu__5070F446");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidade)
                    .HasName("PK__Especial__5676CEFF4F93BBB1");

                entity.ToTable("Especialidade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medico__C326E652D90A6418");

                entity.ToTable("Medico");

                entity.HasIndex(e => e.IdUsuario, "UQ__Medico__5B65BF96E68ECD8A")
                    .IsUnique();

                entity.HasIndex(e => e.Crm, "UQ__Medico__C1FF83F7CF02214B")
                    .IsUnique();

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medico__IdClinic__48CFD27E");

                entity.HasOne(d => d.IdEspecialidadeNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medico__IdEspeci__49C3F6B7");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Medico)
                    .HasForeignKey<Medico>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medico__IdUsuari__47DBAE45");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__Situacao__810BCE3AE40AD5DC");

                entity.ToTable("Situacao");

                entity.Property(e => e.IdSituacao).ValueGeneratedOnAdd();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B1209B455");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario).ValueGeneratedOnAdd();

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97A8394A3C");

                entity.ToTable("Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__IdTipoU__38996AB5");
            });

            modelBuilder.Entity<UsuarioPaciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__UsuarioP__C93DB49BC5399753");

                entity.ToTable("UsuarioPaciente");

                entity.HasIndex(e => e.Rg, "UQ__UsuarioP__32153728E9F1E562")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario, "UQ__UsuarioP__5B65BF961D75A0C0")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__UsuarioP__C1FF93091E4086BD")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.UsuarioPaciente)
                    .HasForeignKey<UsuarioPaciente>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsuarioPa__IdUsu__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
