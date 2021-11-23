using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_022_C.Models
{
    public partial class BelanjakuContext : DbContext
    {
        public BelanjakuContext()
        {
        }

        public BelanjakuContext(DbContextOptions<BelanjakuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Kasir> Kasirs { get; set; }
        public virtual DbSet<Pembeli> Pembelis { get; set; }
        public virtual DbSet<Transaksii> Transaksiis { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Barang");

                entity.Property(e => e.IdBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Barang");

                entity.Property(e => e.HargaBarang)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Harga_Barang");

                entity.Property(e => e.JumlahBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jumlah_Barang");

                entity.Property(e => e.NamaBarang)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Barang");
            });

            modelBuilder.Entity<Kasir>(entity =>
            {
                entity.HasKey(e => e.IdKasir);

                entity.ToTable("Kasir");

                entity.Property(e => e.IdKasir)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Kasir");

                entity.Property(e => e.NamaKasir)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Kasir");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.ToTable("Pembeli");

                entity.Property(e => e.IdPembeli)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Pembeli");

                entity.Property(e => e.IdTransaksi).HasColumnName("Id_Transaksi");

                entity.Property(e => e.NamaPembeli)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Pembeli");
            });

            modelBuilder.Entity<Transaksii>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksii");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Transaksi");

                entity.Property(e => e.IdBarang).HasColumnName("Id_Barang");

                entity.Property(e => e.IdKasir).HasColumnName("Id_Kasir");

                entity.Property(e => e.IdPembeli).HasColumnName("Id_Pembeli");

                entity.Property(e => e.JmlTransaksi)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Jml_Transaksi");

                entity.Property(e => e.UangBayar)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Uang_Bayar");

                entity.Property(e => e.UangKembali)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Uang_Kembali");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Transaksiis)
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("FK_Transaksii_Barang");

                entity.HasOne(d => d.IdKasirNavigation)
                    .WithMany(p => p.Transaksiis)
                    .HasForeignKey(d => d.IdKasir)
                    .HasConstraintName("FK_Transaksii_Kasir");

                entity.HasOne(d => d.IdPembeliNavigation)
                    .WithMany(p => p.Transaksiis)
                    .HasForeignKey(d => d.IdPembeli)
                    .HasConstraintName("FK_Transaksii_Pembeli");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
