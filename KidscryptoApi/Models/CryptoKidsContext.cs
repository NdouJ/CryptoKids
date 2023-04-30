using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KidscryptoApi.Models;

public partial class CryptoKidsContext : DbContext
{
    public CryptoKidsContext()
    {
    }

    public CryptoKidsContext(DbContextOptions<CryptoKidsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Crypto> Cryptos { get; set; }

    public virtual DbSet<CryptoFact> CryptoFacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-N1K2Q5F\\SQLEXPRESS2023;Database=CryptoKids;User Id=sa;Password=SQL;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Crypto>(entity =>
        {
            entity.HasKey(e => e.IdCrypto).HasName("PK__Crypto__0BEB62315599B104");

            entity.ToTable("Crypto");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CryptoFact>(entity =>
        {
            entity.HasKey(e => e.IdCryptoFact).HasName("PK__CryptoFa__C2E8C4F581E10222");

            entity.ToTable("CryptoFact");

            entity.Property(e => e.CryptoFactId).HasColumnName("CryptoFactID");
            entity.Property(e => e.Fact).IsUnicode(false);

            entity.HasOne(d => d.CryptoFactNavigation).WithMany(p => p.CryptoFacts)
                .HasForeignKey(d => d.CryptoFactId)
                .HasConstraintName("FK__CryptoFac__Crypt__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
