using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SENAI_SPMEDICALGROUP_WEBAPI.Domains;

#nullable disable

namespace SENAI_SPMEDICALGROUP_WEBAPI.Contexts
{
    public partial class SpMedicalContext : DbContext
    {
        public SpMedicalContext()
        {
        }

        public SpMedicalContext(DbContextOptions<SpMedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consulta> Consultas { get; set; }
        public virtual DbSet<Lugar> Lugars { get; set; }
        public virtual DbSet<Presença> Presenças { get; set; }
        public virtual DbSet<Situacao> Situacaos { get; set; }
        public virtual DbSet<TipoConsultum> TipoConsulta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<UsuarioMedico> UsuarioMedicos { get; set; }
        public virtual DbSet<UsuarioPaciente> UsuarioPaciente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-E2A5F39\\ASHUALA; initial catalog=SPMEDICALGROUP; user id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__CA9C61F5DA8C3A7B");

                entity.Property(e => e.IdConsulta)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idConsulta");

                entity.Property(e => e.DataConsulta)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdLugar).HasColumnName("idLugar");

                entity.Property(e => e.IdTipoConsulta).HasColumnName("idTipoConsulta");

                entity.Property(e => e.IdUsuarioMedico).HasColumnName("idUsuarioMedico");

                entity.Property(e => e.IdUsuarioPaciente).HasColumnName("idUsuarioPaciente");

                entity.HasOne(d => d.IdLugarNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdLugar)
                    .HasConstraintName("FK__Consultas__idLug__5441852A");

                entity.HasOne(d => d.IdTipoConsultaNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdTipoConsulta)
                    .HasConstraintName("FK__Consultas__idTip__5535A963");

                entity.HasOne(d => d.IdUsuarioMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdUsuarioMedico)
                    .HasConstraintName("FK__Consultas__idUsu__5BE2A6F2");

                entity.HasOne(d => d.IdUsuarioPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdUsuarioPaciente)
                    .HasConstraintName("FK__Consultas__idUsu__5AEE82B9");
            });

            modelBuilder.Entity<Lugar>(entity =>
            {
                entity.HasKey(e => e.IdLugar)
                    .HasName("PK__Lugar__F7460D5FCE1A34D8");

                entity.ToTable("Lugar");

                entity.HasIndex(e => e.Endereco, "UQ__Lugar__9456D4065B89B422")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__Lugar__AA57D6B40EA3F08D")
                    .IsUnique();

                entity.HasIndex(e => e.NomeFantasia, "UQ__Lugar__E7ADFC703989A1D4")
                    .IsUnique();

                entity.Property(e => e.IdLugar)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idLugar");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.HorarioFuncionamento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Presença>(entity =>
            {
                entity.HasKey(e => e.IdPresença)
                    .HasName("PK__Presença__44D2B500BDC31B62");

                entity.ToTable("Presença");

                entity.Property(e => e.IdPresença)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPresença");

                entity.Property(e => e.IdConsulta).HasColumnName("idConsulta");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.IdUsuarioMedico).HasColumnName("idUsuarioMedico");

                entity.Property(e => e.IdUsuarioPaciente).HasColumnName("idUsuarioPaciente");

                entity.HasOne(d => d.IdConsultaNavigation)
                    .WithMany(p => p.Presenças)
                    .HasForeignKey(d => d.IdConsulta)
                    .HasConstraintName("FK__Presença__idCons__5DCAEF64");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Presenças)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Presença__idSitu__5165187F");

                entity.HasOne(d => d.IdUsuarioMedicoNavigation)
                    .WithMany(p => p.Presenças)
                    .HasForeignKey(d => d.IdUsuarioMedico)
                    .HasConstraintName("FK__Presença__idUsua__5070F446");

                entity.HasOne(d => d.IdUsuarioPacienteNavigation)
                    .WithMany(p => p.Presenças)
                    .HasForeignKey(d => d.IdUsuarioPaciente)
                    .HasConstraintName("FK__Presença__idUsua__4F7CD00D");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PK__Situacao__12AFD19747FB697E");

                entity.ToTable("Situacao");

                entity.Property(e => e.IdSituacao)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacao");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoConsultum>(entity =>
            {
                entity.HasKey(e => e.IdTipoConsulta)
                    .HasName("PK__TipoCons__82877167F487C77D");

                entity.HasIndex(e => e.TipoDaConsulta, "UQ__TipoCons__59B9FBE0C5A75DA1")
                    .IsUnique();

                entity.Property(e => e.IdTipoConsulta)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoConsulta");

                entity.Property(e => e.TipoDaConsulta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF17B07AA3");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__TipoUsua__A017BD9F36F45F85")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<UsuarioMedico>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioMedico)
                    .HasName("PK__UsuarioM__EF46912D018A3721");

                entity.ToTable("UsuarioMedico");

                entity.HasIndex(e => e.Cnpj, "UQ__UsuarioM__AA57D6B41D0C8CAF")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__UsuarioM__AB6E6164C1FD63ED")
                    .IsUnique();

                entity.HasIndex(e => e.Crm, "UQ__UsuarioM__C1F887FF88F1FC35")
                    .IsUnique();

                entity.Property(e => e.IdUsuarioMedico)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUsuarioMedico");

                entity.Property(e => e.Clinica)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CRM");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Especialidade)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.RazaoSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.UsuarioMedicos)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__UsuarioMe__idTip__4CA06362");
            });

            modelBuilder.Entity<UsuarioPaciente>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioPaciente)
                    .HasName("PK__UsuarioP__8CCC1A57D21C7E9A");

                entity.ToTable("UsuarioPaciente");

                entity.HasIndex(e => e.Rg, "UQ__UsuarioP__321537C8C5993B82")
                    .IsUnique();

                entity.HasIndex(e => e.Telefone, "UQ__UsuarioP__4EC504B6538E4E37")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__UsuarioP__AB6E61644D544F8B")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__UsuarioP__C1F89731B1F1F86F")
                    .IsUnique();

                entity.Property(e => e.IdUsuarioPaciente)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUsuarioPaciente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DataNascimento)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Endereço)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("endereço");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuarioPaciente)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuarioPaciente");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.UsuarioPacientes)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__UsuarioPa__idTip__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
