using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace USelection.Web.Database
{
    public partial class USelection2Context : DbContext
    {
        public USelection2Context()
        {
        }

        public USelection2Context(DbContextOptions<USelection2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Exception> Exceptions { get; set; }
        public virtual DbSet<IzbornaJedinica> IzbornaJedinicas { get; set; }
        public virtual DbSet<IzbornaJedinicaKandidat> IzbornaJedinicaKandidats { get; set; }
        public virtual DbSet<Kandidat> Kandidats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=USelection2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Exception>(entity =>
            {
                entity.ToTable("Exception");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Poruka)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IzbornaJedinica>(entity =>
            {
                entity.ToTable("IzbornaJedinica");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IzbornaJedinicaKandidat>(entity =>
            {
                entity.ToTable("IzbornaJedinicaKandidat");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IzbornaJedinicaId).HasColumnName("IzbornaJedinicaID");

                entity.Property(e => e.KandidatId).HasColumnName("KandidatID");

                entity.HasOne(d => d.IzbornaJedinica)
                    .WithMany(p => p.IzbornaJedinicaKandidats)
                    .HasForeignKey(d => d.IzbornaJedinicaId)
                    .HasConstraintName("FK__IzbornaJe__Izbor__2A4B4B5E");

                entity.HasOne(d => d.Kandidat)
                    .WithMany(p => p.IzbornaJedinicaKandidats)
                    .HasForeignKey(d => d.KandidatId)
                    .HasConstraintName("FK__IzbornaJe__Kandi__2B3F6F97");
            });

            modelBuilder.Entity<Kandidat>(entity =>
            {
                entity.ToTable("Kandidat");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImeIprezime)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ImeIPrezime");

                entity.Property(e => e.SifraKandidata)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
